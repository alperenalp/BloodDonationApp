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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserValidateResponse> ValidateUserAsync(ValidateUserLoginRequest request)
        {
            var users = await _userRepository.GetAllAsync();
            var response = users.SingleOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            return _mapper.Map<UserValidateResponse>(response);
        }

        public async Task<int> CreateUserAsync(CreateNewUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            return await _userRepository.CreateAsync(user);
        }
    }
}
