using CodeTo.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeTo.Core.ViewModel.AdminPanel
{
    public static class ConvertVmToModel
    {
        public static User ConvertVmToModelUser(this AdminPanelIndexViewModel admin)
        {
            return new User()
            {
                AvatarName = admin.AvatarName,
                CreateDate = admin.CreateDate,
                Email = admin.Email,
                IsEmailActive = admin.IsActived,
                UserName = admin.UserName
            };
        }

        public static IQueryable<User> ConvertVmToModelUser(this IQueryable<AdminPanelIndexViewModel> admins)
        {
            return admins.Select(u => u.ConvertVmToModelUser());
        }
        public static IEnumerable<User> ConvertVmToModelUser(this IEnumerable<AdminPanelIndexViewModel> admins)
        {
            return admins.Select(u => u.ConvertVmToModelUser());
        }
    }
}
