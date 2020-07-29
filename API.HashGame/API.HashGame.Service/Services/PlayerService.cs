using API.HashGame.Data.Context;
using API.HashGame.Data.Enumerator;
using API.HashGame.Data.Models;
using API.HashGame.Services.DTO.Game;
using API.HashGame.Services.DTO.Player;
using API.HashGame.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.HashGame.Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HashGameContext _context;

        private readonly IMapper _mapper;

        private const string POSITION_X = "X";
        private const string POSITION_Y = "Y";
        public PlayerService(HashGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GameOutputDto CreatePlayers(Guid gameId)
        {
            if (GetGame(gameId) != null)
            {
                Guid guidX = Guid.NewGuid();
                Guid guidY = Guid.NewGuid();

                Player playerX = new Player { Id = guidX, Name = POSITION_X, GameId = gameId };
                Player playerY = new Player { Id = guidY, Name = POSITION_Y, GameId = gameId };

                this._context.Players.Add(playerX);
                this._context.Players.Add(playerY);
                this._context.SaveChanges();

                var retorno = _context.Games
                              .Include(join => join.Players)
                              .Where(ga => ga.Id.Equals(gameId))
                              .FirstOrDefault();

                return _mapper.Map<GameOutputDto>(retorno);
            }
            else
            {
                throw new Exception(string.Format(Messages.Message.GameNotFound, gameId.ToString()));
            }
        }

        public PlayerOutputDto JoinGame(Guid gameId)
        {
            Player player = GetPlayerByGameId(gameId);

            if (player != null)
            {

                if (player.IsUsed == true)
                {
                    player.IsUsed = false;
                    this._context.Players.Update(player);
                    this._context.SaveChanges();
                    player = this._context.Players.Where(p => p.GameId == gameId && p.Id != player.Id)?.First();
                }

                player.IsUsed = true;

                this._context.Players.Update(player);
                this._context.SaveChanges();

                return _mapper.Map<PlayerOutputDto>(player);
            }
            else
            {
                throw new Exception(Messages.Message.PlayerNotExist);
            }
        }
        public PlayerOutputDto UnJoinGame(PlayerInputDto input)
        {
            Player player = this._context.Players.Where(p => p.Id.Equals(input.Id)).First();

            if (player != null)
            {
                player.IsUsed = false;

                this._context.Players.Update(player);
                this._context.SaveChanges();

                return _mapper.Map<PlayerOutputDto>(player);
            }
            else
            {
                throw new Exception(Messages.Message.PlayerNotExist);
            }
        }
        public PlayerOutputDto Moviment(PlayerInputDto playerToMove)
        {
            List<Dictionary<string, List<int>>> oldState = new List<Dictionary<string, List<int>>>();

            Player player = GetPlayerId(playerToMove.Id);

            if (player == null)
            {
                throw new Exception(string.Format(Messages.Message.PlayerNotFound, playerToMove.Id.ToString()));
            }

            Game game = GetGame(player.GameId);

            if (player.Name.ToLower() == game.CurrentTurn.ToLower())
            {
                player.XPosition = playerToMove.XPosition;
                player.YPosition = playerToMove.YPosition;

                if (!string.IsNullOrEmpty(game.GameState))
                {
                    Dictionary<string, List<int>> gameState = new Dictionary<string, List<int>>();

                    gameState.Add(player.Name.ToLower(),
                                  new List<int>(new int[]
                                                { player.XPosition,
                                                  player.YPosition }));

                    oldState = JsonConvert.DeserializeObject<List<Dictionary<string, List<int>>>>(game.GameState).ToList();

                    oldState.Add(gameState);

                    string currentState = JsonConvert.SerializeObject(oldState);

                    game.GameState = currentState;
                }
                else
                {
                    Dictionary<string, List<int>> gameState = new Dictionary<string, List<int>>();

                    gameState.Add(player.Name.ToLower(),
                                  new List<int>(new int[]
                                  { player.XPosition,
                                    player.YPosition }));

                    oldState = new List<Dictionary<string, List<int>>>();

                    oldState.Add(gameState);

                    string currentState = JsonConvert.SerializeObject(oldState);

                    game.GameState = currentState;
                }

                if (game.CurrentTurn.Equals(POSITION_X))
                {
                    game.CurrentTurn = POSITION_Y;
                }
                else
                {
                    game.CurrentTurn = POSITION_X;
                }

                game.Status = CheckPlayerWins(game.GameState);

                this._context.Players.Update(player);
                this._context.Games.Update(game);
                this._context.SaveChanges();

                return _mapper.Map<PlayerOutputDto>(player);

            }
            else
            {
                throw new Exception(Messages.Message.NotPlayerTurn);
            }
        }
        private StatusEnum CheckPlayerWins(string gameState)
        {
            List<Dictionary<string, List<int>>> state = JsonConvert.DeserializeObject<List<Dictionary<string, List<int>>>>(gameState).ToList();

            List<Dictionary<string, List<int>>> playerX = state.Where(px => px.Any(value => value.Key.ToUpper().Equals(POSITION_X))).ToList();

            List<Dictionary<string, List<int>>> playerY = state.Where(px => px.Any(value => value.Key.ToUpper().Equals(POSITION_Y))).ToList();

            if (playerY.Count >= 3 && IsWin(playerY))
            {
                return StatusEnum.VencedorY;
            }

            else if (playerX.Count >= 3 && IsWin(playerX))
            {
                return StatusEnum.VencedorX;
            }
            else if (state.Count >= 9)
            {
                return StatusEnum.Empate;
            }
            else
            {
                return StatusEnum.EmAndamento;
            }
        }

        private bool IsWin(List<Dictionary<string, List<int>>> player)
        {
            bool win = false;

            List<bool> diagonal = new List<bool>();
            List<bool> sequence = new List<bool>();
            List<int> vertical = new List<int>();
            List<int> horizontal = new List<int>();

            int posX = default(int);
            int posY = default(int);

            player.ForEach(dictMove =>
            {
                dictMove.Values.ToList().ForEach(listValues =>
                {
                    posX = listValues[0];
                    posY = listValues[1];

                    if (posX == posY)
                    {
                        diagonal.Add(true);
                    };
                    if (posX + posY == 2)
                    {
                        sequence.Add(true);
                    }

                    vertical.Add(posX);
                    horizontal.Add(posY);
                });
            });

            if (diagonal.Count >= 3 || sequence.Count >= 3)
            {
                win = true;
                return win;
            }

            vertical.Sort();

            horizontal.Sort();
            int quantidadeRepetidosX = GetListRepeatedItem(vertical);
            int quantidadeRepetidosY = GetListRepeatedItem(horizontal);

            if (quantidadeRepetidosX >= 3 || quantidadeRepetidosY >= 3)
            {
                win = true;
            }

            return win;
        }

        private int GetListRepeatedItem(List<int> vertical)
        {

            Dictionary<int, int> listaNumeros = new Dictionary<int, int>();

            vertical.ForEach(item =>
            {
                int val;
                if (listaNumeros.TryGetValue(item, out val))
                {

                    listaNumeros[item] = val + 1;
                }
                else
                {

                    listaNumeros.Add(item, 1);
                }
            });

            return listaNumeros.Values.Max();
        }

        private Game GetGame(Guid gameId)
        {
            return this._context.Games.Where(game => game.Id.Equals(gameId))?.First();
        }

        private Player GetPlayerByGameId(Guid gameId)
        {
            return this._context.Players.Where(p => p.GameId == gameId)?.First();
        }

        private Player GetPlayerId(Guid id)
        {
            return this._context.Players.Where(p => p.Id == id)?.First();
        }

    }
}