using CodeTo.Core.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.AccountVm
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterVm vm);
        Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm);
        Task<bool> IsDuplicatedEmail(string email);
        Task<bool> IsDuplicatedUsername(string username);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<UserDetailVm> GetUserByIdAsync(int userId);
        Task<UserInformation> GetUserInformation(string username);
        Task<bool> ActiveAccountAsync(string activecode);
        Task<UserPanelData> GetUserPanelData(string username);
       
    }
}
