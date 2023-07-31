using AutoMapper;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Data.Contexts;
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

        public async Task<IEnumerable<BloodDisplayResponse>> GetAllBloodsAsync()
        {
            var bloods = await _bloodRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<BloodDisplayResponse>>(bloods);
            return response;
        }

        public async Task<BloodDisplayResponse> GetBloodByIdAsync(int id)
        {
            var blood = await _bloodRepository.GetByIdAsync(id);
            var response = _mapper.Map<BloodDisplayResponse>(blood);
            return response;
        }

        public async Task<string> GetBloodTypeByIdAsync(int bloodId)
        {
            var blood = await _bloodRepository.GetByIdAsync(bloodId);
            return blood.Type;
        }
    }
}
