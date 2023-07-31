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
            //Users
            CreateMap<User, UserValidateResponse>().ReverseMap();
            CreateMap<User, ValidateUserLoginRequest>().ReverseMap();
            CreateMap<User, CreateNewUserRequest>().ReverseMap();
            CreateMap<User, UserDisplayResponse>().ReverseMap();
            CreateMap<User, CreateNewHospitalUserRequest>().ReverseMap();
            CreateMap<User, HospitalUserDisplayResponse>().ReverseMap();
            CreateMap<User, UpdateHospitalUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();

            //Hospitals
            CreateMap<Hospital, CreateNewHospitalRequest>().ReverseMap();
            CreateMap<Hospital, HospitalDisplayResponse>().ReverseMap();
            CreateMap<Hospital, UpdateHospitalRequest>().ReverseMap();

            //Bloods
            CreateMap<Blood, BloodTypeResponse>().ReverseMap();
            CreateMap<Blood, CreateNewHospitalBloodRequest>().ReverseMap();

            //HospitalBloods
            CreateMap<HospitalBlood, HospitalBloodsDisplayResponse>().ReverseMap();
            CreateMap<HospitalBlood, UpdateHospitalBloodRequest>().ReverseMap();
        }
    }
}
