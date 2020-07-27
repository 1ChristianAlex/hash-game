using System;
using HashGame.Interface;
using HashGame.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HashGame.Service
{
    public class GameService : IGameService
    {
        private readonly DbContextGame _context;

        public GameService(DbContextGame context)
        {
            _context = context;
        }
        public string CreateGame(int id)
        {
            return Guid.NewGuid().ToString();
        }
    }
}