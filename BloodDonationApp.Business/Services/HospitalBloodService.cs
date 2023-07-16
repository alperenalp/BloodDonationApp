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
    public class HospitalBloodService : IHospitalBloodService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IBloodRepository _bloodRepository;
        private readonly IMapper _mapper;

        public HospitalBloodService(IBloodRepository bloodRepository, IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _bloodRepository = bloodRepository;
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        public async Task AddNeedForBloodAsync(CreateNewHospitalBloodRequest request, int hospitalId)
        {
            var hospital = await _hospitalRepository.GetHospitalByIdWithBloodsAsync(hospitalId);

            hospital.HospitalBloods.Add(new HospitalBlood
            {
                BloodId = request.BloodId,
                HospitalId = hospital.Id,
                Quantity = request.Quantity,
            });

            await _hospitalRepository.UpdateAsync(hospital);
        }

        public async Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListByBloodIdAsync(int bloodId)
        {
            var hospitals = await _hospitalRepository.GetHospitalListByBloodIdAsync(bloodId);
            return _mapper.Map<IEnumerable<HospitalDisplayResponse>>(hospitals);
        }

        public async Task<IEnumerable<HospitalBloodsDisplayResponse>> GetHospitalBloodListAsync(int hospitalId)
        {
            var hospital = await _hospitalRepository.GetHospitalByIdWithBloodsAsync(hospitalId);
            var hospitalBloods = _mapper.Map<IEnumerable<HospitalBloodsDisplayResponse>>(hospital.HospitalBloods);
            return hospitalBloods;
        }
    }
}
