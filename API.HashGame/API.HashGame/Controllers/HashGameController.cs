using API.HashGame.Services.DTO.Game;
using API.HashGame.Services.DTO.Player;
using API.HashGame.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.HashGame.Controllers
{
    [Route("[controller]")]
    public class HashGameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;

        public HashGameController(IGameService gameService, IPlayerService playerService)
        {
            _gameService = gameService;
            _playerService = playerService;
        }

        [HttpPost]
        public ActionResult<GameOutputDto> CreateGameSession()
        {
            Guid gameCriado = _gameService.CreateGame().Id;
            var retorno = _playerService.CreatePlayers(gameCriado);
            return Ok(retorno);
        }

        [HttpGet]
        public ActionResult<GameOutputDto> GetAllGames()
        {
            var gameList = _gameService.GetAll();
            return Ok(gameList);
        }

        [Route("{id}/join")]
        [HttpPost]
        public ActionResult<PlayerOutputDto> JoinGame(Guid id)
        {
            try
            {
                var player = _playerService.JoinGame(id);
                return Ok(player);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("{id}/moviment")]
        public ActionResult<PlayerOutputDto> Moviment(int id, [FromBody] PlayerInputDto input)
        {
            try
            {
                var player = _playerService.Moviment(input);
                return Ok(player);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}