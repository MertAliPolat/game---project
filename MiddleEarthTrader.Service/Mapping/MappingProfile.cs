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
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.NationName, opt => opt.MapFrom(src => src.Nation.Name));

            CreateMap<Material, MaterialDto>()
    .ForMember(dest => dest.CreatedByUsername,
               opt => opt.MapFrom(src => src.CreatedByUser.Username))
    .ForMember(dest => dest.NationName,
               opt => opt.MapFrom(src => src.CreatedByUser.Nation.Name));

        }
    }
}