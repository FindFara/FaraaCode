using CodeTo.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Permissions;

namespace CodeTo.Domain.Entities.Users
{
    public class Role : BaseEntity<int>
    {
        public string RoleTitle { get; set; }

        #region Relations
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
