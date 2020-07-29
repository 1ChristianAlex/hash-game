using API.HashGame.Data.Context;
using API.HashGame.Data.Enumerator;
using API.HashGame.Data.Models;
using API.HashGame.Services.DTO.Game;
using API.HashGame.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.HashGame.Services.Services
{
    public class GameService : IGameService
    {
        private readonly HashGameContext _context;
        private readonly IMapper _mapper;

        private const string POSITION_X = "X";
        private const string POSITION_Y = "Y";


        public GameService(HashGameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GameOutputDto CreateGame()
        {
            Random rnd = new Random();

            int firstPlayerRandom = rnd.Next(0, 10);

            string firstPlayer;

            if (firstPlayerRandom % 2 == 0)
            {
                firstPlayer = POSITION_X;
            }
            else
            {
                firstPlayer = POSITION_Y;
            }

            Game newGame = new Game { CurrentTurn = firstPlayer, Status = StatusEnum.EmAndamento };
            
            this._context.Games.Add(newGame);
            this._context.SaveChanges();

            var retorno = _context.Games.Where(ga => ga.Id.Equals(newGame.Id)).FirstOrDefault();

            return _mapper.Map<GameOutputDto>(newGame);
        }

        public IEnumerable<GameOutputDto> GetAll()
        {
            return _mapper.Map<IEnumerable<GameOutputDto>>(_context.Games
                                                           .Include(join => join.Players)
                                                           .OrderByDescending(game=> game.CreateDate));
        }

        public GameOutputDto GetById(Guid id)
        {
            return _mapper.Map<GameOutputDto>(_context.Games
                                                           .Include(join => join.Players)
                                                           .Where(ga=> ga.Id.Equals(id))
                                                           .First());
        }
    }
}