using AutoMapper;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync(); 
            return _mapper.Map<IEnumerable<UserDto>>(users); 
        }
    }

}
