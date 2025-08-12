
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Service.Services;
using System.Collections.Generic;

namespace MiddleEarthTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        private readonly IGameEventService _gameEventService;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IMaterialService materialService, IGameEventService gameEventService, ILogger<MaterialController> logger)
        {
            _materialService = materialService;
            _gameEventService = gameEventService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterials()
        {
            var materials = await _materialService.GetAllAsync();
            return Ok(materials);
        }

        [HttpPost("ModifyPrices")]
        public async Task<IActionResult> ModifyPrices([FromBody] List<MaterialPriceModifierDto> modifiers)
        {
            if (modifiers == null || !modifiers.Any())
                return BadRequest("Geçersiz veri.");

            await _materialService.ModifyPricesAsync(modifiers);
            return Ok("Fiyatlar başarıyla güncellendi.");
        }
    }
}