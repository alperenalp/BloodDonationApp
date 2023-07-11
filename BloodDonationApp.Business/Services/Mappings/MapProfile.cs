using AutoMapper;
using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserValidateResponse>().ReverseMap();
            CreateMap<User, ValidateUserLoginRequest>().ReverseMap();
            CreateMap<User, CreateNewUserRequest>().ReverseMap();
        }
    }
}
