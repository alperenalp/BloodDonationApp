﻿using AutoMapper;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Contexts;
using BloodDonationApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository _bloodRepository;
        private readonly IMapper _mapper;

        public BloodService(IBloodRepository bloodRepository, IMapper mapper)
        {
            _bloodRepository = bloodRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BloodTypeResponse>> GetAllBloodsAsync()
        {
            var bloods = await _bloodRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<BloodTypeResponse>>(bloods);
            return response;
        }
    }
}
