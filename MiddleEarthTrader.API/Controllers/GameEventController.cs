using Microsoft.AspNetCore.Mvc;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Service.Services;

namespace MiddleEarthTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameEventController : ControllerBase
    {
        private readonly IGameEventService _gameEventService;
        public GameEventController(IGameEventService gameEventService)
        {
            _gameEventService = gameEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameEventDto>>> GetAllEvents()
        {
            var gameEvents = await _gameEventService.GetAllAsync();
            return Ok(gameEvents);
        }
    }
}
