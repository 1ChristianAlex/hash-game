using API.HashGame.Services.DTO.Game;
using System;
using System.Collections.Generic;

namespace API.HashGame.Services.Services.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Cria novo um Game
        /// </summary>
        /// <returns></returns>
        GameOutputDto CreateGame();

        /// <summary>
        /// Retorna todos os Games
        /// </summary>
        /// <returns></returns>
        IEnumerable<GameOutputDto> GetAll();

        GameOutputDto GetById(Guid id);

    }
}