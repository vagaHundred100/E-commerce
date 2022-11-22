using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface IAccountService
    {
        Task<DefaultResult> RegisterUser(UserCreateDTO userRegisterViewModel);
        //Task<DataResult<LoginedUserDTO>> Login(LoginDTO loginData);
        //DataResult<List<UserDropDownDTO>> AllUsersForDropDown();
        PagedDataResult<List<UsersDTO>> AllUsers(PaginationSettings paginationSettings); // all users
        //PagedDataResult<List<UserViewDTO>> AllUsers(PaginationSettings paginationSettings);
        //PagedDataResult<List<RoleViewDTO>> AllRoles(PaginationSettings paginationSettings);
        //PagedDataResult<List<RoleDropDownDTO>> AllRolesForDropDownPaged(PaginationSettings paginationSettings);
        Task<DefaultResult> DeactivateUser(int userId);
        Task<DefaultResult> ActivateUser(int userId);
        Task<DefaultResult> DeactivateRole(int roleId);
        Task<DefaultResult> AssignUserToRole(int userId, int roleId);
        Task<DefaultResult> AssignUserToRoles(int userId, List<int> roleIds);
        Task<DefaultResult> UpdateUserRoles(int userId, List<int> roleIds);
        Task<DefaultResult> SelectApplicationLanguage(int userId, int appLangId);
        //Task<DataResult<List<UserRolesViewDTO>>> UserRoles(int userId);
        Task<DefaultResult> RemoveUserFromRole(int userId, int roleId);
        //Task<DefaultResult> EditUser(UserUpdateDTO userEditModel);
        Task<DefaultResult> CreateRole(string roleName);
        DataResult<List<KeyValuePair<string, int>>> UserTypes();
        Task<DefaultResult> ResetPassword(UserResetPasswordDTO userChangePasswordDTO);
        Task<DefaultResult> ChangePassword(UserChangePasswordDTO userChangePasswordDTO);
    }
}