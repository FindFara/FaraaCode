using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string PermissionTitle { get; set; }
        public string PermissionName { get; set; }
        public  int? ParentId { get; set; }

        #region Relations

        [ForeignKey("ParentId")]
        public List<RolePermission> Permissions { get; set; }
        public Role Roles { get; set; }

        #endregion


    }
}
