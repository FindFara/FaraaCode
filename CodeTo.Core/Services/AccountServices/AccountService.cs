using CodeTo.Core.Extensions;
using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extension;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.Users;
using CodeTo.DataEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.AccountServices
{

    public class AccountService : IAccountService
    {
        private readonly CodeToContext _context;
        private readonly ISecurityService _securityService;
        private readonly ILoggerService<AccountService> _logger;

        public AccountService(CodeToContext context, ISecurityService securityService, ILoggerService<AccountService> logger)
        {
            _context = context;
            _securityService = securityService;
            _logger = logger;
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

        public async Task<bool> IsDuplicatedUsername(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName==username); 
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var user=await _context.Users.AddAsync(new Domain.Entities.User.User
                {
                    ActiveCode=GeneratorGuid.GeneratorUniqCode(),
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
            user.ActiveCode = GeneratorGuid.GeneratorUniqCode();
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

        public async Task<UserPanelDataVm> GetUserPanelData(string username)
        {
            //UserPanelDataVm ud = new UserPanelDataVm();
            //var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            //ud.UserName = user.UserName;
            //ud.RegisterDate = user.RegisterDate;
            //ud.ImageName = user.UserAvatar; 

            //return ud;

            return await _context.Users
            .Where(u => u.UserName == username)
            .Select(u => new UserPanelDataVm()
            {
                UserName = u.UserName,
                ImageName = u.UserAvatar,
                RegisterDate = u.RegisterDate
            }).SingleAsync();
        }

        public async Task<EditProfileVm> GetEditPrifileData(string username)
        {
            return await _context.Users
            .Where(u => u.UserName == username)
            .Select(u => new EditProfileVm()
            {
                UserName = u.UserName,
                AvatarName = u.UserAvatar,
                Email = u.Email
            }).SingleAsync();
        }


        public async Task<bool> GetEditProfile(string username ,EditProfileVm profile)
        {

            try
            {
                var user = await _context.Users.FindAsync(username,profile.UserName);

                if (profile.AvatarFile != null)
                {
                    var UserImageName = DateTime.Now.ToString("MM-dd-yyyy_") + profile.AvatarFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    profile.AvatarFile.AddImageToServer(UserImageName, PathTools.UserImageServerPath, thumbSize, profile.AvatarName);
                    user.UserAvatar = UserImageName;
                }

                user.UserName = profile.UserName;
                user.Email = profile.Email;
                user.UserAvatar = profile.AvatarName;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
