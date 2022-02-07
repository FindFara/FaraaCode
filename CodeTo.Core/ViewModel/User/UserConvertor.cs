using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.User;


namespace CodeTo.Core.ViewModel.User
{
   public static class UserConvertor
    {
        public static UserDetailVm ToDetailViewModel(this Domain.Entities.User.User user)
        {
            return new UserDetailVm
            {
                Id = user.Id,
                UserName =user.UserName,
                Email = user.Email,
                Password=user.Password,
                RegisterDate=user.RegisterDate,
                UserAvatar=user.UserAvatar,
                IsActive = user.IsActive,
                ActiveCode = user.ActiveCode,
            };
        }
        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<Domain.Entities.User.User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }


    }
}

