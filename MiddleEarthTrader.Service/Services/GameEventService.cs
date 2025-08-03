using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.Interfaces;
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
    public class GameEventService : IGameEventService
    {
        private readonly GameEventRepository _GameEventRepository;
        private readonly IMapper _mapper;

        public GameEventService(GameEventRepository gameEventRepository, IMapper mapper)
        {
            _GameEventRepository = gameEventRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameEventDto>> GetAllAsync()
        {
            var gameEvents = await _GameEventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameEventDto>>(gameEvents);
        }

    }

   
    }
