using CodeTo.Core.ViewModel.Users;
using CodeTo.Domain.Entities.Users;
using CodeTo.Domain.Entities.Wallet;
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


        #region Wallet
        
        int GetUserIdByUserName(string username);
        int UserBalanceAsync(string username);
        List<WalletViewModel> ShowHistory(string username);
        long ChargeUserWallet(int amount, string username, string Description, bool ISpay = false);
        long AddWallet(Wallet wallet);
        public Wallet GetWalletByWalletId(long walletid);
        public void UpdateWallet(Wallet wallet);

        #endregion
    }
}
