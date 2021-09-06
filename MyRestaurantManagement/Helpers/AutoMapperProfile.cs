using AutoMapper;
using MyRestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, UserModel>();
            CreateMap<LoginModel, UserModel>();
            CreateMap<UpdateUserModel, UserModel>();
        }
    }
}
