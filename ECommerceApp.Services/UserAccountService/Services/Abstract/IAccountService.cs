using ECommerceApp.Domain.Entities;
using ECommerceApp.Services.UserAccountService.DTOs;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ECommerceApp.Services.UserAccountService.Services.Abstract
{
    public interface IAccountService
    {
        Task<DefaultResult> RegisterUser(RegisterDTO userRegisterViewModel);
        Task<DataResult<string>> Login(LoginDTO loginData);
        //DataResult<List<UserDropDownDTO>> AllUsersForDropDown();
        //PagedDataResult<List<UserDropDownDTO>> AllUsersForDropDownPaged(PaginationSettings paginationSettings);
        PagedDataResult<List<UserViewDTO>> AllUsers(PaginationSettings paginationSettings);
        //PagedDataResult<List<RoleViewDTO>> AllRoles(PaginationSettings paginationSettings);
        //PagedDataResult<List<RoleDropDownDTO>> AllRolesForDropDownPaged(PaginationSettings paginationSettings);
        Task<DefaultResult> DeactivateUser(int userId);
        Task<DefaultResult> ActivateUser(int userId);
        Task<DefaultResult> DeactivateRole(int roleId);
        Task<DefaultResult> AssignUserToRole(UserRoleDTO userRole);
        Task<DefaultResult> AssignUserToRoles(int userId, List<string> rols);
        Task<DefaultResult> UpdateUserRoles(int userId, List<int> roleIds);
        Task<DefaultResult> SelectApplicationLanguage(int userId, int appLangId);
        //Task<DataResult<List<UserRolesViewDTO>>> UserRoles(int userId);
        Task<DefaultResult> RemoveUserFromRole(UserRoleDTO userRole);
        //Task<DefaultResult> EditUser(UserUpdateDTO userEditModel);
        Task<DefaultResult> CreateRole(string role);
        Task<DataResult<AppRole>> GetRoleById(int id);
        Task<DefaultResult> UpdateRole(int id, RoleDTO roleDTO);
        Task<DefaultResult> DeleteRole(int id);
        DataResult<List<KeyValuePair<string, int>>> UserTypes();
        Task<DefaultResult> ResetPassword(UserResetPasswordDTO userChangePasswordDTO);
        Task<DefaultResult> ChangePassword(UserChangePasswordDTO userChangePasswordDTO);
        DataResult<List<AppRole>> AllRoles();
    }
}