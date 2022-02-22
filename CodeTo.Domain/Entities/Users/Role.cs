using CodeTo.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Domain.Entities.Users
{
    public class Role : BaseEntity<int>
    {
        public Role()
        {

        }

     
        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }


        #region Relations

        public virtual List<UserRole> UserRoles { get; set; }


        #endregion
    }
}
