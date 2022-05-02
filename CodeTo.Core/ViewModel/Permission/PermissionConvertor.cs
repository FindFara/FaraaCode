using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bz.ClassFinder.Models;
using CodeTo.Domain.Entities.Permissions;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Core.ViewModel.Permission
{
    public static class PermissionConvertor
    {
        #region ShowRole
        public static ShowRoleViewModel ToShowRoleViewModel(this Role r)
        {
            return new ShowRoleViewModel
            {
                RoleId = r.Id,
                RoleName = r.RoleTitle
            };
        }

        #endregion

        #region RolePermissionAddOrEditViewModel

        public static RolePermissionAddOrEditViewModel ToRolePermissionAddEditViewModel(this Role r)
        {
            return new RolePermissionAddOrEditViewModel
            {
                RoleId = r.Id,
                RoleName = r.RoleTitle,
                Permissions = {new BzClassInfo()}
            };
        }


        #endregion

        #region Permissions

        public static PermissionsViewModel ToPermissionsViewModel(this RolePermission p)
        {
            return new PermissionsViewModel
            {
                Id = p.Id,
                PermissionName = p.PermissionName,
                PermissionTitle = p.PermissionTitle,
               
            };
        }

        #endregion

        #region UserRole

        public static UserRoleViewModel ToUserRoleViewModel(this UserRole p)
        {
            return new UserRoleViewModel
            {
                UserRoleId = p.UR,
                UserId = p.UserId,
                RoleId = p.RoleId,
            };
        }

        #endregion
    }
}
