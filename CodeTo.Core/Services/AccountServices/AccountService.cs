using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.Accounts;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.AccountServices
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

        public async Task<bool> CheckEmailAndPasswordAsync(AccountLoginViewModel vm)

        {
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email.Trim().ToLower() == vm.Email.Trim().ToLower());
            if (user != null)
            {
                return _securityService.VerifyHashedPassword(user.Password, vm.Password);
            }
            return false;
        }

        public async Task<UserDetailViewModel> GetUserByEmailAsync(string email)
        {
            email = email.Trim().ToLower();
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Email == email);

            return user.ToUserDetailViewModel();
        }

        public async Task<UserDetailViewModel> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
               .SingleOrDefaultAsync(c => c.Id == userId);
            return user.ToUserDetailViewModel();
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            return await _context.Users.AnyAsync(c => c.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public async Task<bool> IsDuplicatedUsername(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }

        public async Task<bool> RegisterAsync(AccountRegisterViewModel vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var user = await _context.Users.AddAsync(new User
                {
                    EmailActiveCode = GeneratorGuid.GeneratorUniqCode(),
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = hassPassword,
                    CreateDate = DateTime.Now,
                    IsEmailActive = false

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

        public async Task<bool> ActiveAccountAsync(string EmailActiveCode)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailActiveCode == EmailActiveCode);
            if (user == null || user.IsEmailActive == false)
                return false;
            user.IsEmailActive = true;
            user.EmailActiveCode = GeneratorGuid.GeneratorUniqCode();
            _context.SaveChanges();
            return true;
        }



       
    }
}
