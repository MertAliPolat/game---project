
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IMaterialService materialService, IGameEventService gameEventService,IInventoryService inventoryService, ILogger<MaterialController> logger)
        {
            _materialService = materialService;
            _gameEventService = gameEventService;
            _inventoryService = inventoryService;
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
        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromBody] BuyRequestDto request)
        {
            var result = await _inventoryService.BuyMaterialAsync(request.UserId, request.MaterialId, request.Quantity);
            return Ok(result);
        }

        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromBody] BuyRequestDto request)
        {
            var result = await _inventoryService.SellMaterialAsync(request.UserId, request.MaterialId, request.Quantity);
            return Ok(result);
        }

    }
}