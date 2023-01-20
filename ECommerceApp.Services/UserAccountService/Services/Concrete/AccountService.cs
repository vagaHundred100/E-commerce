﻿using AutoMapper;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Services.UserAccountService.Identity.Concrete;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Shared.HelperExtentionMethods;
using ECommerceApp.Shared.SharedRequestResults.Base;
using ECommerceApp.Shared.SharedRequestResults.SharedEnum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

        public async Task<DefaultResult> RegisterUser(RegisterDTO userRegisterViewModel)
        {
            var user = new AppUser();
            user = _mapper.Map<RegisterDTO, AppUser>(userRegisterViewModel, user);
            var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);

            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }

        public async Task<DefaultResult> DeactivateUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            user.Status = EntityStatus.Inactive;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }

        public async Task<DefaultResult> ActivateUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            user.Status = EntityStatus.Active;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }

        public async Task<DefaultResult> DeactivateRole(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                return new DefaultResult(false);
            }

            role.Status = EntityStatus.Inactive;

            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();

        }

        public async Task<DefaultResult> AssignUserToRole(int userId, int roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            var result = await _userManager.AddToRoleAsync(user, roleId.ToString());

            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }

            return new DefaultResult();
        }

        public async Task<DefaultResult> AssignUserToRoles(int userId, List<int> roleIds)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            foreach (var roleId in roleIds)
            {
                var result = await _userManager.AddToRoleAsync(user, roleId.ToString());
                if (!result.Succeeded)
                {
                    return new DefaultResult(result.Succeeded);
                }
            }

            return new DefaultResult();
        }

        public async Task<DefaultResult> UpdateUserRoles(int userId, List<int> roleIds)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            foreach (var roleId in roleIds)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                var result = await _roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    return new DefaultResult(result.Succeeded);
                }
            }

            return new DefaultResult();
        }

        public async Task<DefaultResult> SelectApplicationLanguage(int userId, int appLangId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DefaultResult> RemoveUserFromRole(int userId, int roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new DefaultResult(false);
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleId.ToString());

            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }

            return new DefaultResult();
        }

        public async Task<DefaultResult> CreateRole(RoleDTO roleDTO)
        {
            AppRole role = new AppRole();
            role.Name = roleDTO.Name;
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return new DefaultResult(result.Succeeded);
            }
            return new DefaultResult();
        }

        public async Task<DefaultResult> UpdateRole(int id, RoleDTO roleDTO)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            role.Name = roleDTO.Name;
            var response = await _roleManager.UpdateAsync(role);
            return new DefaultResult(response.Succeeded);
        }
        public async Task<DefaultResult> DeleteRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            return new DefaultResult(result.Succeeded);
        }
        public async Task<DataResult<AppRole>> GetRoleById(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return new DataResult<AppRole>(role);
        }

        public DataResult<List<KeyValuePair<string, int>>> UserTypes()
        {
            throw new System.NotImplementedException();
        }

        public PagedDataResult<List<UserViewDTO>> AllUsers(PaginationSettings settings)
        {

            var userDTOs = _userManager.Users
                   .Skip((settings.PageNumber - 1) * settings.PageSize)
                   .Take(settings.PageSize)
                   .Select(u =>
                         new UserViewDTO
                         {
                             UserName = u.UserName,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Email = u.Email
                         })
                   .AsEnumerable()
                   .ToList();


            var count = userDTOs.Count();
            return new PagedDataResult<List<UserViewDTO>>(
                       userDTOs, settings.PageNumber, settings.PageSize, count);
        }

        public async Task<DataResult<string>> Login(LoginDTO loginData)
        {
            var user = await _userManager.FindByNameAsync(loginData.UserName);

            if (user == null)
            {
                var result = new DataResult<string>(null);
                result.Message = "User with such login does not exist"; // magic strings 
                return result;
            }

            var isSucceded = await _userManager.CheckPasswordAsync(user, loginData.Password);

            if (isSucceded == false)
            {
                DataResult<string> result = new DataResult<string>(null);
                result.Succeeded = false;
                result.Message = "Passward or login was incorect";
                return result;
            }
            else
            {
                var userClaimOptions = _mapper.Map<UserClaimsOptions>(user);
                var roles = await _userManager.GetRolesAsync(user);


                return _jwtTokenService.GenerateJwt(userClaimOptions, roles, _jwtOptions);
            }

        }

        public DataResult<List<AppRole>> AllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return new DataResult<List<AppRole>>(roles);
        }
    }
}