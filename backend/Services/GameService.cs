using System;
using System.Collections.Generic;
using System.Linq;
using HashGame.Interface;
using HashGame.Models;

namespace HashGame.Service
{
    public class GameService : IGameService
    {
        private readonly DbContextGame _context;

        public GameService(DbContextGame context)
        {
            _context = context;
        }
        public Game CreateGame()
        {
            Random rnd = new Random();
            int firstPlayerRandom = rnd.Next(0, 10);

            string firstPlayer;

            if (firstPlayerRandom % 2 == 0)
            {
                firstPlayer = "x";
            }
            else
            {
                firstPlayer = "y";
            }

            var guid = Guid.NewGuid().ToString();

            Game newGame = new Game { guid = guid, firstPlayer = firstPlayer, currentTurn = firstPlayer };

            var values = this._context.Add<Game>(newGame);
            this._context.SaveChanges();
            return newGame;
        }

        public List<Game> GetAll()
        {
            return this._context.Games.ToList();
        }
    }
}