using CodeTo.Domain.Entities.Users;
using CodeTo.Domain.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Accounts;
using JetBrains.Annotations;

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
       

        #region Wallet

        int GetUserIdByUserName(string username);
        Task<int> UserBalanceAsync(string username);
        
        Task<List<WalletHistoryViewModel>> ShowHistory(string username);
        Task<int> ChargeUserWallet(int amount, string username, string Description, bool ISpay = false);
        long AddWallet(Wallet wallet);
         Wallet GetWalletByWalletId(long walletid);
         void UpdateWallet(Wallet wallet);

        #endregion
    }
}
