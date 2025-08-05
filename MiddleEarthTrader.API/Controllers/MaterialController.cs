using Microsoft.AspNetCore.Mvc;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Service.Dtos;
using System.Collections.Generic;

namespace MiddleEarthTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService, IGameEventService gameEventService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterials()
        {
            var materials = await _materialService.GetAllAsync();
            return Ok(materials);
        }

        [HttpPost("modify-prices")]
        public async Task<IActionResult> ModifyPrices([FromBody] List<MaterialPriceModifierDto> modifiers)
        {
            if (modifiers == null || !modifiers.Any())
                return BadRequest("Geçersiz veri.");

            await _materialService.ModifyPricesAsync(modifiers);
            return Ok("Fiyatlar başarıyla güncellendi.");
        }
    }
}