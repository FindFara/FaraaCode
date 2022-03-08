using CodeTo.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.AdminPanel
{
    public static class AdminPanelConvertor
    {
        public static AdminPanelIndexViewModel ConvertorAdminPanelIndexViewModel(this User user)
        {
            if (user == null) return null;
            return new AdminPanelIndexViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id,
                AvatarImageName = user.AvatarImageName,
                CreateDate = user.CreateDate,
                IsActived = user.IsEmailActive
            };
        }

        public static IQueryable<AdminPanelIndexViewModel> ConvertorAdminPanelIndexViewModel(
            this IQueryable<User> users)
        {
            return users.Select(u => u.ConvertorAdminPanelIndexViewModel());
        }

        public static IEnumerable<AdminPanelIndexViewModel> ConvertorAdminPanelIndexViewModel(
            this IEnumerable<User> users)
        {
            return users.Select(u => u.ConvertorAdminPanelIndexViewModel());
        }

        public static AdminPanelCreateOrEditViewModel ConvertorAdminPanelCreatOrEditViewModel(this User user)
        {
            return new AdminPanelCreateOrEditViewModel()
            {
                Title = user.UserName,
                Email = user.Email,
                Id = user.Id,
                AvatarImageName = user.AvatarImageName,
                CreateDate = user.CreateDate,
                Password = user.Password,
            };
        }

        public static IQueryable<AdminPanelCreateOrEditViewModel> ConvertorAdminPanelCreatOrEditViewModel(
            this IQueryable<User> users)
        {
            return users.Select(u => u.ConvertorAdminPanelCreatOrEditViewModel());
        }
    }
}
