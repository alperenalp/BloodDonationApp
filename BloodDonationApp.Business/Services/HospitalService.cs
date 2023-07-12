using AutoMapper;
using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Data.Repositories;
using BloodDonationApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public HospitalService(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        public async Task CreateHospitalAsync(CreateNewHospitalRequest request)
        {
            var hospital = _mapper.Map<Hospital>(request);
            await _hospitalRepository.CreateAsync(hospital);
        }

        public async Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListAsync()
        {
            var hospitals = await _hospitalRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HospitalDisplayResponse>>(hospitals);
        }
    }
}
