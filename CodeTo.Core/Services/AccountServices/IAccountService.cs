using CodeTo.Core.ViewModel.Users;
using CodeTo.Domain.Entities.Users;
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
        Task<bool> ActiveAccountAsync(string activecode);

    }
}
