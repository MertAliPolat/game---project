using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleEarthTrader.Service.Dtos;


namespace MiddleEarthTrader.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDto>
    {
        Task<bool> LoginAsync(UserLoginDto loginDto);
        Task<ProfileDto> GetProfileAsync(Guid userId);
    }
}
