using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Identity.Concrete;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.SharedRequestResults.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Concrete
{
    public sealed class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AccountService(IMapper mapper, IJwtTokenService jwtTokenService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IOptionsSnapshot<JwtOptions> jwtSettings)
        {
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _jwtOptions = jwtSettings.Value;
            _userManager = userManager;
            _roleManager = roleManager;
        }
      
        public async Task<DefaultResult> ResetPassword(UserResetPasswordDTO userChangePasswordDTO)
        {
            IdentityResult? result = null;
            AppUser? user = _userManager.Users.SingleOrDefault(u => u.Id == userChangePasswordDTO.UserId && u.Status == EntityStatus.Active);
            if (user is null)
            {
                return new DefaultResult(false);
            }
            string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            result = await _userManager.ResetPasswordAsync(user, passResetToken, userChangePasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }
        public async Task<DefaultResult> ChangePassword(UserChangePasswordDTO userChangePasswordDTO)
        {
            IdentityResult? result = null;
            AppUser? user = _userManager.Users.SingleOrDefault(u => u.Id == userChangePasswordDTO.UserId && u.Status == EntityStatus.Active);
            if (user is null)
            {
                return new DefaultResult(false);
            }
            result = await _userManager.ChangePasswordAsync(user, userChangePasswordDTO.OldPassword, userChangePasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }
        public Task<DefaultResult> RegisterUser(UserCreateDTO userRegisterViewModel)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> DeactivateUser(int userId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> ActivateUser(int userId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> DeactivateRole(int roleId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> AssignUserToRole(int userId, int roleId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> AssignUserToRoles(int userId, List<int> roleIds)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> UpdateUserRoles(int userId, List<int> roleIds)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> SelectApplicationLanguage(int userId, int appLangId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> RemoveUserFromRole(int userId, int roleId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<DefaultResult> CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }
        public DataResult<List<KeyValuePair<string, int>>> UserTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}