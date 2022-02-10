
using CodeTo.Core.Services.AccountVm;
using CodeTo.Core.Utilities.Extension;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.User;
using CodeTo.DataEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.AccountService
{

    public class AccountService : IAccountService
    {
        private readonly CodeToContext _context;
        private readonly ISecurityService _securityService;

        public AccountService(CodeToContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        

        public async Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm)

        {
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email.Trim().ToLower() == vm.Email.Trim().ToLower());
            if (user != null)
            {
                return _securityService.VerifyHashedPassword(user.Password, vm.Password);
            }
            return false;
        }

        public async Task<UserDetailVm> GetUserByEmailAsync(string email)
        {
            email = email.Trim().ToLower();
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Email == email);

            return user.ToDetailViewModel();
        }

        public async Task<UserDetailVm> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
               .SingleOrDefaultAsync(c => c.Id == userId);
            return user.ToDetailViewModel();
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            return await _context.Users.AnyAsync(c => c.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var user=await _context.Users.AddAsync(new Domain.Entities.User.User
                {
                    ActiveCode=Generator.GeneratorUniqCode(),
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = hassPassword,
                    RegisterDate = DateTime.Now,
                    IsActive=false

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }
        
        public async Task<bool> ActiveAccountAsync(string activecode)
        {
            var user =await _context.Users.SingleOrDefaultAsync(u => u.ActiveCode == activecode);
            if (user == null || user.IsActive==false)
                return false;
            user.IsActive = true;
            user.ActiveCode = Generator.GeneratorUniqCode();
            _context.SaveChanges();
            return true;
        }

        public async Task<UserDetailVm> GetUserInformation(string username)
        {
            var user =await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            UserDetailVm uv = new UserDetailVm();
            {
                uv.UserName = user.UserName;
                uv.Email = user.Email;
                uv.RegisterDate = user.RegisterDate;
                uv.Wallet = 0;
            }
            return uv;
        }
    }
}
