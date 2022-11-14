using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;

namespace ECommerceApp.Services.UserAccountService.Mapping
{
    public class UserAccountMapping : Profile
    {
        public UserAccountMapping()
        {
            CreateMap<UserCreateDTO, AppUser>().ReverseMap();
        }
    }
}