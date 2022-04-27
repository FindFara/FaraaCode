using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.Permission
{
    public class ShowRoleViewModel
    {
        public int RoleId { get; set; }
        [Display(Name = "نام نقش")]
        public string RoleName { get; set; }
    }
    public class UserRoleViewModel
    {
        [Display(Name = "شناسه")]
        public int UserRoleId { get; set; }
        [Display(Name = "شناسه کاربر")]
        public int UserId { get; set; }
        [Display(Name = "شناسه نقش")]
        public int RoleId { get; set; }
        [Display(Name = "نام نقش")]
        public string RoleTitle { get; set; }
    }
   
}
