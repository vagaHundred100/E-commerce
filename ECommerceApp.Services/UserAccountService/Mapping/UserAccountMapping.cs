using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Identity.Abstract;
using ECommerceApp.Services.UserAccountService.Identity.Concrete;

namespace ECommerceApp.Services.UserAccountService.Mapping
{
    public class UserAccountMapping : Profile
    {
        public UserAccountMapping()
        {
            CreateMap<UserCreateDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, UserClaimsOptions>();
        }
    }
}