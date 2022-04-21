using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bz.ClassFinder.Models;
using CodeTo.Core.Statics;

namespace CodeTo.Core.ViewModel.Permission
{
   public class RolePermissionAddOrEditViewModel
    {
        public RolePermissionAddOrEditViewModel()
        {
            PermissionNames = new List<string>();
        }
        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        public string RoleName { get; set; }
        public string PermissionTitle { get; set; }
        public List<BzClassInfo> Permissions => Values.Permissions;
        //public List<BzClassInfo> Permissions { get; set; } = Values.Permissions;
        [Display(Name = "دسترسی")]
        public List<string> PermissionNames { get; set; }
    }
}
