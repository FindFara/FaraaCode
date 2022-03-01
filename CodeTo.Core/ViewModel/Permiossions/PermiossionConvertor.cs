using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Core.ViewModel.PermiossionViewModel
{
   public static class PermiossionConvertor
    {
        public static PermissionIndexViewModel permissionToVM(this Role role)
        {
            return new PermissionIndexViewModel()
            {
                Id = role.RoleID,
                Title = role.RoleTitle
            };
        }

        public static IQueryable<PermissionIndexViewModel> permissionToVM(this IQueryable<Role> roles)
        {
            return roles.Select(r => r.permissionToVM());
        }


        public static IEnumerable<PermissionIndexViewModel> permissionToVM(this IEnumerable<Role> roles)
        {
            return roles.Select(r => r.permissionToVM());
        }
    }

    public static class ConvertCreateOrEditeToVm
    {
        public static PermissionCreateorEditeViewModel convertTovm(this Role role)
        {
            return new PermissionCreateorEditeViewModel()
            {
                Id = role.RoleID,
                CreateDate = role.CreatDate,
                Title = role.RoleTitle
            };
        }

        public static IQueryable<PermissionCreateorEditeViewModel> convertTovm(this IQueryable<Role> roles)
        {
            return roles.Select(r => r.convertTovm());
        }
    }
}
