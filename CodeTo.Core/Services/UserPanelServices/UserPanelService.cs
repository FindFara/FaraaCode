using CodeTo.Core.Extensions;
using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extension;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.Users;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.UserPanelServices
{
     public class UserPanelService :IUserPanelService
    {
        private readonly CodeToContext _context;
        private readonly ILoggerService<UserPanelService> _logger;
        private readonly ISecurityService _security;

        public UserPanelService(CodeToContext context, ILoggerService<UserPanelService> logger, ISecurityService security)
        {
            _context = context;
            _logger = logger;
            _security = security;
        }
        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

        }
        public async Task<UserPanelInformationViewModel> GetUserInformation(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            UserPanelInformationViewModel uv = new UserPanelInformationViewModel();
            {
                uv.UserName = user.UserName;
                uv.Email = user.Email;
                uv.CreateDate = user.CreateDate;
                uv.Wallet = 0;
            }
            return uv;
        }

        public async Task<UserPanelDataViewModel> GetUserPanelData(string username)
        {
            //UserPanelDataVm ud = new UserPanelDataVm();
            //var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            //ud.UserName = user.UserName;
            //ud.RegisterDate = user.RegisterDate;
            //ud.ImageName = user.UserAvatar; 

            //return ud;

            return await _context.Users
            .Where(u => u.UserName == username)
            .Select(u => new UserPanelDataViewModel()
            {
                UserName = u.UserName,
                AvatarName = u.AvatarName,
                CreateDate = u.CreateDate
            }).SingleAsync();
        }

        public async Task<EditProfileViewModel> GetEditProfileData(string username)
        {
            return await _context.Users
            .Where(u => u.UserName == username)
            .Select(u => new EditProfileViewModel()
            {
                UserName = u.UserName,
                AvatarName = u.AvatarName,
                Email = u.Email
            }).SingleAsync();
        }

        public async Task<bool> EditProfile(string username, EditProfileViewModel profile)
        {
            try
            {
                var user = await GetUserByUserNameAsync(username);
                string UserImageName = null;
                if (profile.AvatarFile != null)
                {
                    UserImageName = GeneratorGuid.GeneratorUniqCode() + profile.AvatarFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    profile.AvatarFile.AddImageToServer(UserImageName, PathTools.UserImageServerPath, thumbSize, profile.AvatarName);
                    user.AvatarName = UserImageName;
                }




                user.UserName = profile.UserName;
                user.Email = profile.Email;
                user.AvatarName = UserImageName;

                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        public async Task<bool> compareOldPassword(string username, string oldpassword)
        {

            var hashepasssword = _security.HashPassword(oldpassword);


            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                return false;
            }
            return _security.VerifyHashedPassword(user.Password, hashepasssword);

        }

        public async Task<bool> ChangePassword(string username, string newpassword)
        {
            var user = await GetUserByUserNameAsync(username);
            if (user == null) return false;
            user.Password = _security.HashPassword(newpassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
