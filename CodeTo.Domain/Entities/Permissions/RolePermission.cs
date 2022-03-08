using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Domain.Entities.Permissions
{
    public class RolePermission : BaseEntity<int>
    {
        public int RoleId { get; set; }
        public string PermissionName { get; set; }

        #region Relations
        public Role Roles { get; set; }
        #endregion


    }
}
