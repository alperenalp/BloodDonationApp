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
            user.Type = "User";
            return await _userRepository.CreateAsync(user);
        }

        public async Task<IEnumerable<UserDisplayResponse>> GetUserListAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDisplayResponse>>(users);
        }

        public async Task<IEnumerable<HospitalUserDisplayResponse>> GetHospitalUserListAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var response = users.Where(x => x.Type == "Hospital").ToList();
            return _mapper.Map<IEnumerable<HospitalUserDisplayResponse>>(response);
        }

        public async Task<int> CreateHospitalUserAsync(CreateNewHospitalUserRequest request)
        {
            var hospitalUser = _mapper.Map<User>(request);
            hospitalUser.Type = "Hospital";
            return await _userRepository.CreateAsync(hospitalUser);
        }

        public async Task<UserDisplayResponse> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDisplayResponse>(user);
        }

        public async Task<bool> IsUserExistsAsync(int id)
        {
            return await _userRepository.IsExistsAsync(id);
        }

        public async Task UpdateHospitalUserAsync(UpdateHospitalUserRequest request)
        {
            var hospitalUser = _mapper.Map<User>(request);
            hospitalUser.Type = "Hospital";
            await _userRepository.UpdateAsync(hospitalUser);
        }

        public async Task<UpdateHospitalUserRequest> GetHospitalUserByIdForUpdateAsync(int id)
        {
            var hospitalUser = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateHospitalUserRequest>(hospitalUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task UpdateUserAsync(UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> IsExistsUserByUsernameAsync(string username)
        {
            return await _userRepository.IsExistsUserByUsernameAsync(username);
        }
    }
}
