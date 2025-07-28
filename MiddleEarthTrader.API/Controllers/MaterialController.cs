using Microsoft.AspNetCore.Mvc;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Service.Dtos;

namespace MiddleEarthTrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterials()
        {
            var materials = await _materialService.GetAllAsync();
            return Ok(materials);
        }
    }
}
