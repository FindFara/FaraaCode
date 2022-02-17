using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Users;


namespace CodeTo.Core.ViewModel.Users
{
    public static class ConvertorToViewModel
    {
        #region ToUserDetailViewModel


        public static UserDetailViewModel ToUserDetailViewModel(this Domain.Entities.User.User user)
        {
            return new UserDetailViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreateDate = user.CreateDate,
                //AvatarName = user.UserAvatar,
                IsActive = user.IsActive,
                ActiveCode = user.ActiveCode,

            };
        }
        public static IQueryable<UserDetailViewModel> ToUserDetailViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToUserDetailViewModel());
        }
        #endregion
        #region ToEditProfileViewModel


        public static EditProfileViewModel ToEditProfileViewModel(this Domain.Entities.User.User user)
        {
            return new EditProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AvatarName = user.AvatarName



            };
        }
        public static IQueryable<EditProfileViewModel> ToEditProfileViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToEditProfileViewModel());
        }
        #endregion
        #region ToAccountRegisterViewModel
        public static AccountRegisterViewModel ToAccountRegisterViewModel(this Domain.Entities.User.User user)
        {
            return new AccountRegisterViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AvatarName = user.AvatarName,
                ActiveCode=user.ActiveCode,
                IsActive=user.IsActive,
                Password=user.Password,
                CreateDate=user.CreateDate


            };
        }
        public static IQueryable<AccountRegisterViewModel> ToAccountRegisterViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToAccountRegisterViewModel());
        }
        #endregion

    }
}

