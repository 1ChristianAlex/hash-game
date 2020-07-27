using Game.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [Route("game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // Create a new game session
        [HttpPost]
        public ActionResult<dynamic> CreateGameSession([FromBody] CreateGameDTO value)
        {
            return Ok(value.id);
        }

        [HttpPost]
        [Route("{id}/movement")]
        public ActionResult<string> Movement(int id, [FromBody] MoveGameDTO value)
        {
            return Ok("Hello world" + value.position["x"]);
        }
    }
}