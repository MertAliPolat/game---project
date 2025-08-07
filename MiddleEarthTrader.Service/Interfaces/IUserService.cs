using MiddleEarthTrader.Repository.Entities;
using MiddleEarthTrader.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiddleEarthTrader.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDto>
    {
        Task<User?> LoginAsync(UserLoginDto loginDto);
        Task<ProfileDto> GetProfileAsync(Guid userId);
    }
}
