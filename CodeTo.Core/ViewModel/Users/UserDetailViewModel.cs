using CodeTo.Core.Statics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.Users
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string AvatarName { get; set; }
        public int Wallet { get; set; }

    }

    public class UserPanelDataViewModel
    {
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string AvatarName { get; set; }
        public string AcatarFullName =>
          !string.IsNullOrEmpty(AvatarName)
          ? $"{PathTools.UserImagePath}{AvatarName}"
          : PathTools.UserImageDefautl;

    }
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        public IFormFile AvatarFile { get; set; }
        public string AvatarName { get; set; }
        public string AcatarFullName =>
           !string.IsNullOrEmpty(AvatarName)
           ? $"{PathTools.UserImagePath}{AvatarName}"
           : PathTools.UserImageDefautl;

    }
}