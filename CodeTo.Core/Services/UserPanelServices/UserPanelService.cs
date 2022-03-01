using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.Accounts;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Users;
using CodeTo.Domain.Entities.Wallet;
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
        

        public UserPanelService(CodeToContext context, ILoggerService<UserPanelService> logger, ISecurityService security )
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
                uv.Wallet =UserBalanceAsync(username); 
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
                AvatarImageName = u.AvatarImageName,
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
                AvatarImageName = u.AvatarImageName,
                Email = u.Email
                
            }).SingleAsync();
        }

        public async Task<bool> EditProfile(string username, EditProfileViewModel profile)
        {
            try
            {
                var user = await GetUserByUserNameAsync(username);
                string UserImageName = null;
                if (profile.AvatarImageFile != null)
                {
                    UserImageName = GeneratorGuid.GeneratorUniqCode() + profile.AvatarImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    profile.AvatarImageFile.AddImageToServer(UserImageName, UserPathTools.UserImageServerPath, thumbSize, profile.AvatarImageName);
                    user.AvatarImageName = UserImageName;
                }

                user.UserName = profile.UserName;
                user.Email = profile.Email;
                user.AvatarImageName = UserImageName;
                
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

            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            return _security.VerifyHashedPassword(user.Password, oldpassword);
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



        public int GetUserIdByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username).Id;
        }

        public int UserBalanceAsync(string username)
        {
            var Userid = GetUserIdByUserName(username);
            var deposit = _context.Wallets.Where(w => w.UserId == Userid && w.WalletTypeId == 1 && w.Ispay)
                .Select(w => w.Amount)
                .ToList();
            var withdraw = _context.Wallets.Where(w => w.UserId == Userid && w.WalletTypeId == 2 && w.Ispay)
                .Select(w => w.Amount)
                .ToList();
            return ((int)(deposit.Sum() - withdraw.Sum()));

        }

        public async Task<List<WalletHistoryViewModel>> ShowHistory(string username)
        {
            
            var userid = GetUserIdByUserName(username);
            return  _context.Wallets.Where(w => w.UserId == userid && w.Ispay)
                .Select(w => new WalletHistoryViewModel()
                {
                    Amount = w.Amount,
                    Creatdate = w.CreatDate,
                    Description = w.Description,
                    TypeId = w.WalletTypeId
                }).ToList();
        }

        public int ChargeUserWallet(int amount, string username, string Description, bool ISpay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                UserId =  GetUserIdByUserName(username),
                CreatDate = DateTime.Now,
                Description = Description,
                WalletTypeId = 1
            };
            return (int)AddWallet(wallet);
        }

        public long AddWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.Id;
        }

        public Wallet GetWalletByWalletId(long walletid)
        {
            return _context.Wallets.Find(walletid);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }
    }
}
