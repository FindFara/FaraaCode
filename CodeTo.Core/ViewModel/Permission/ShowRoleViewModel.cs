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
        public int Id { get; set; }
        [Display(Name = "نام نقش")]
        public string Name { get; set; }
    }
}
