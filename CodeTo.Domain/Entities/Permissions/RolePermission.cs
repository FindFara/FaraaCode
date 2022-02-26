using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Domain.Entities.Permissions
{
   public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int PermissionId { get; set; }
        public byte RoleId { get; set; }
        #region Relations
        public Role Role { get; set; }
        public Permission Permission { get; set; }


        #endregion
    }
}
