using CodeTo.Core.ViewModel.Users;
using CodeTo.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.AccountServices
{
    public interface IAccountService 
    {
        Task<bool> RegisterAsync(AccountRegisterViewModel vm);
        Task<bool> CheckEmailAndPasswordAsync(AccountLoginViewModel vm);
        Task<bool> IsDuplicatedEmail(string email);
        Task<bool> IsDuplicatedUsername(string username);
        Task<UserDetailViewModel> GetUserByEmailAsync(string email);
        Task<UserDetailViewModel> GetUserByIdAsync(int userId);
        Task<User> GetUserByUserNameAsync(string username);
        Task<bool> ActiveAccountAsync(string activecode);

        #region UserProfile
        Task<UserDetailViewModel> GetUserInformation(string username);
        Task<UserPanelDataViewModel> GetUserPanelData(string username);
        Task<EditProfileViewModel> GetEditPrifileData(string username);
        Task<bool> EditProfile(string username, EditProfileViewModel profile);
        
       
        #endregion


    }
}
