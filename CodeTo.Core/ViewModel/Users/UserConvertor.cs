using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Users;


namespace CodeTo.Core.ViewModel.Users
{
    public static class UserConvertor
    {
        public static UserDetailVm ToDetailViewModel(this Domain.Entities.User.User user)
        {
            return new UserDetailVm
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RegisterDate = user.RegisterDate,
                AvatarName = user.UserAvatar,
                IsActive = user.IsActive,
                ActiveCode = user.ActiveCode,
            };
        }
        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }
        public static EditProfileVm ToEditProfileViewModel(this Domain.Entities.User.User user)
        {
            return new EditProfileVm
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AvatarName = user.UserAvatar

            };
        }
        public static IQueryable<EditProfileVm> ToEditProfileViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToEditProfileViewModel());
        }


    }
}

