using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Permission;

namespace CodeTo.Core.Services.PermissionServices
{
    public interface IPermissionService
    {
        IQueryable<ShowRoleViewModel> GetAllRoles();
        Task<bool> AddRoleAsync(RolePermissionAddOrEditViewModel vm);
        Task<RolePermissionAddOrEditViewModel> FindRoleAsync(int id);
        Task<bool> UpdateRole(RolePermissionAddOrEditViewModel vm);
        bool ExistsRole(int id);
        Task<bool> RemoveRoleAsync(int id);
        void RemoveRolePermissions(int roleId);
        Task<bool> CheckPermission(string permissionName);
        bool IsSupperAdmin();
        Task<IList<string>> GetCurrentUserPermissionsAsync();
        bool IsRemovable(int roleId);
        Task<List<PermissionsViewModel>> GetAllPermission();
    }
}
