using AutoMapper;
using MiddleEarthTrader.Repository.Repositories;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly MaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(MaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync()
        {
                       var materials = await _materialRepository.GetAllMaterialsAsync();
            return _mapper.Map<IEnumerable<MaterialDto>>(materials);
        }




    }
}
