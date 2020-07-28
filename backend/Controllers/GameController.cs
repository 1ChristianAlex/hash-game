using HashGame.DTO;
using HashGame.Interface;
using HashGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace HashGame.Controllers
{
    [Route("game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        private readonly IPlayerService _playerService;

        public GameController(IGameService gameService, IPlayerService playerService)
        {
            _gameService = gameService;
            _playerService = playerService;
        }
        // Create a new game session
        [HttpPost]
        public ActionResult<Game> CreateGameSession([FromBody] CreateGameDTO value)
        {
            var gameCreated = _gameService.CreateGame();
            _playerService.CreatePlayers(gameCreated.id);
            return Ok(gameCreated);
        }
        [Route("all")]
        [HttpGet]
        public ActionResult<Game> GetAllGames()
        {
            var gameList = _gameService.GetAll();
            return Ok(gameList);
        }
        [Route("{id}/join")]
        [HttpPost]
        public ActionResult<Player> JoinGame(int id)
        {
            try
            {
                var player = _playerService.JoinGame(id);

                return Ok(player);
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        [Route("{id}/movement")]
        public ActionResult<Player> Movement(int id, [FromBody] MoveGameDTO value)
        {
            try
            {
                var player = this._playerService.Moviment(value.id, value.xPosition, value.yPosition);
                return Ok(player);
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

    }
}