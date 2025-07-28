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

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllUsersAsync(); 
            return _mapper.Map<IEnumerable<UserDto>>(users); 
        }

        public async Task<bool> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);

            if (user == null)
                return false;

            // Şifre kontrolü (örnek: plain text karşılaştırma)
            return user.PasswordHash == loginDto.Password;

            // Şifreler hash'li ise:
            // return BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
        }
    }

}
