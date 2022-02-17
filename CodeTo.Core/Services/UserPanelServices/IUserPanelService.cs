using CodeTo.Core.ViewModel.Users;
using CodeTo.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.UserPanelServices
{
   public interface IUserPanelService
    {
        Task<User> GetUserByUserNameAsync(string username);
        Task<UserPanelInformationViewModel> GetUserInformation(string username);
        Task<UserPanelDataViewModel> GetUserPanelData(string username);
        Task<EditProfileViewModel> GetEditProfileData(string username);
        Task<bool> EditProfile(string username, EditProfileViewModel profile);
        Task<bool> compareOldPassword(string username, string oldpassword);
        Task<bool> ChangePassword(string username, string newpassword);
    }
}
