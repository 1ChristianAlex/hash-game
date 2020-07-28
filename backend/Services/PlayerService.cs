using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using HashGame.Interface;
using HashGame.Models;

namespace HashGame.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly DbContextGame _context;

        public PlayerService(DbContextGame context)
        {
            _context = context;
        }

        public void CreatePlayers(int gameId)
        {
            var guidx = Guid.NewGuid().ToString();
            var guidy = Guid.NewGuid().ToString();
            Player playerX = new Player { guid = guidx, player = "X", gameId = gameId };
            Player playerY = new Player { guid = guidy, player = "Y", gameId = gameId };
            this._context.Add<Player>(playerX);
            this._context.Add<Player>(playerY);
            this._context.SaveChanges();
        }

        public Player JoinGame(int gameId)
        {
            try
            {
                var player = this._context.Players.Where(player => player.gameId == gameId
             && player.login == false).First();

                player.login = true;

                this._context.Players.Update(player);
                this._context.SaveChanges();

                return player;
            }
            catch (System.Exception)
            {

                throw new Exception("Partida não encontrada");
            }
        }

        public Player Moviment(int playerId, int positionX, int positionY)
        {

            var player = this._context.Players.Where(player => player.id == playerId).First();
            var game = this._context.Games.Where(game => game.id == player.gameId).First();
            if (player.player.ToLower() == game.currentTurn.ToLower())
            {
                player.xPosition = positionX;
                player.yPosition = positionY;


                if (!String.IsNullOrEmpty(game.gameState))
                {
                    Dictionary<string, List<int>> gameState = new Dictionary<string, List<int>>();
                    gameState.Add(player.player.ToLower(), new List<int>(new int[] { positionX, positionY }));
                    var oldState = JsonSerializer.Deserialize<List<Dictionary<string, List<int>>>>(game.gameState).ToList();
                    oldState.Add(gameState);

                    var currentState = JsonSerializer.Serialize(oldState);



                    game.gameState = currentState;
                }
                else
                {
                    Dictionary<string, List<int>> gameState = new Dictionary<string, List<int>>();
                    gameState.Add(player.player.ToLower(), new List<int>(new int[] { positionX, positionY }));
                    var oldState = new List<Dictionary<string, List<int>>>();
                    oldState.Add(gameState);

                    var currentState = JsonSerializer.Serialize(oldState);


                    game.gameState = currentState;
                }


                if (game.currentTurn == "X")
                {
                    game.currentTurn = "Y";
                }
                else
                {
                    game.currentTurn = "X";
                }
                string check = CheckPlayerWins(game.gameState);
                game.status = check;
                this._context.Players.Update(player);
                this._context.Games.Update(game);
                this._context.SaveChanges();



                return player;
            }
            else
            {
                throw new Exception("Não é turno do jogador");
            }
        }
        public string CheckPlayerWins(string gameState)
        {
            List<Dictionary<string, List<int>>> state = JsonSerializer.Deserialize<List<Dictionary<string, List<int>>>>(gameState).ToList();

            List<Dictionary<string, List<int>>> playerX = state.FindAll(pX => pX.Keys.ToList().Any(item => item == "x") == true);

            List<Dictionary<string, List<int>>> playerY = state.FindAll(pX => pX.Keys.ToList().Any(item => item == "y") == true);

            bool IsWin(List<Dictionary<string, List<int>>> player)
            {
                bool win = false;
                List<bool> diagonal = new List<bool>();
                List<int> vertical = new List<int>();
                List<int> horizontal = new List<int>();
                player.ForEach(dictMove =>
                {
                    dictMove.Values.ToList().ForEach(listValues =>
                    {
                        int posX = listValues[0];
                        int posY = listValues[1];

                        if (posX == posY)
                        {
                            diagonal.Add(true);
                        };
                        vertical.Add(posX);
                        horizontal.Add(posY);
                    });
                });

                if (diagonal.Count > 3)
                {
                    win = true;
                }
                List<bool> verticalCount = new List<bool>();
                vertical.Sort();
                int auxo = vertical.First();
                for (int i = 0; i < vertical.Count; i++)
                {
                    if (vertical[i] == auxo)
                    {
                        verticalCount.Add(true);
                    }
                    else
                    {
                        verticalCount.Clear();
                        auxo = vertical[i];
                    }
                }

                List<bool> horizontalCount = new List<bool>();
                horizontal.Sort();
                int auxoHo = horizontal.First();
                for (int i = 0; i < horizontal.Count; i++)
                {
                    if (horizontal[i] == auxoHo)
                    {
                        horizontalCount.Add(true);
                    }
                    else
                    {
                        horizontalCount.Clear();
                        auxoHo = vertical[i];
                    }
                }


                if (horizontalCount.Count > 3 || verticalCount.Count > 3)
                {
                    win = true;
                }
                return win;
            }

            if (playerY.Count > 3 && IsWin(playerY))
            {
                var dict = new Dictionary<string, string>();
                dict.Add("msg", "Partida finalizada");
                dict.Add("winner", "Y");

                return JsonSerializer.Serialize(dict);

            }
            if (playerX.Count > 3 && IsWin(playerX))
            {
                var dict = new Dictionary<string, string>();
                dict.Add("msg", "Partida finalizada");
                dict.Add("winner", "X");
                return JsonSerializer.Serialize(dict);
            }
            else if (state.Count >= 9)
            {
                var dict = new Dictionary<string, string>();
                dict.Add("status", "Partida finalizada");
                dict.Add("winner", "Draw");
                return JsonSerializer.Serialize(dict);
            }
            else
            {
                var dict = new Dictionary<string, string>();
                dict.Add("status", "Partida em andamento");
                return JsonSerializer.Serialize(dict);
            }

        }
    }
}