using HashGame.DTO;
using HashGame.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HashGame.Controllers
{
    [Route("game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        // Create a new game session
        [HttpPost]
        public ActionResult<dynamic> CreateGameSession([FromBody] CreateGameDTO value)
        {
            string guid = _gameService.CreateGame(value.id);
            return Ok(guid);
        }

        [HttpPost]
        [Route("{id}/movement")]
        public ActionResult<string> Movement(int id, [FromBody] MoveGameDTO value)
        {
            return Ok("Hello world" + value.position["x"]);
        }
    }
}