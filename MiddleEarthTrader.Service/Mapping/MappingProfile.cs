using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MiddleEarthTrader.Repository.Entities;
using MiddleEarthTrader.Service.Dtos;

namespace MiddleEarthTrader.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(dest => dest.NationName, opt => opt.MapFrom(src => src.Nation.Name))
                .ForMember(dest => dest.PriceChangePercentage, opt => opt.MapFrom(src =>
                    src.BasePrice == 0 ? 0 : ((src.CurrentPrice - src.BasePrice) / src.BasePrice) * 100));

            CreateMap<MaterialPriceModifierDto, MaterialPriceModifier>();
            CreateMap<GameEvent, GameEventDto>().ReverseMap();
        }
    }
}