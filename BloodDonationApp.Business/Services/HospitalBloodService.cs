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
        private readonly IHospitalBloodRepository _hospitalBloodRepository;
        private readonly IMapper _mapper;

        public HospitalBloodService(IBloodRepository bloodRepository, IHospitalRepository hospitalRepository, IMapper mapper, IHospitalBloodRepository hospitalBloodRepository)
        {
            _bloodRepository = bloodRepository;
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
            _hospitalBloodRepository = hospitalBloodRepository;
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

        public async Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListForNeedsBloodByBloodIdAsync(int bloodId)
        {
            var hospitals = await _hospitalRepository.GetHospitalListForNeedsBloodByBloodIdAsync(bloodId);
            return _mapper.Map<IEnumerable<HospitalDisplayResponse>>(hospitals);
        }

        public async Task<IEnumerable<HospitalBloodsDisplayResponse>> GetHospitalBloodListAsync(int hospitalId)
        {
            var hospital = await _hospitalRepository.GetHospitalByIdWithBloodsAsync(hospitalId);
            var hospitalBloods = _mapper.Map<IEnumerable<HospitalBloodsDisplayResponse>>(hospital.HospitalBloods);
            return hospitalBloods;
        }

        public async Task<bool> IsExistsBloodInHospital(int bloodId, int hospitalId)
        {
            return await _hospitalBloodRepository.isExists(bloodId, hospitalId);
        }

        public async Task<UpdateHospitalBloodRequest> GetHospitalBloodForUpdateAsync(int hospitalId, int bloodId)
        {
            var hospitalBlood = await _hospitalBloodRepository.GetHospitalBloodAsync(hospitalId, bloodId);
            return _mapper.Map<UpdateHospitalBloodRequest>(hospitalBlood);
        }

        public async Task UpdateHospitalBloodAsync(UpdateHospitalBloodRequest request)
        {
            var hospitalBlood = _mapper.Map<HospitalBlood>(request);
            await _hospitalBloodRepository.UpdateHospitalBloodAsync(hospitalBlood);
        }
    }
}
