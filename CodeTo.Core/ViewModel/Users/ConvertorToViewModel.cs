using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Users;


namespace CodeTo.Core.ViewModel.Users
{
    public static class ConvertorToViewModel
    {
        #region ToUserDetailViewModel


        public static UserDetailViewModel ToUserDetailViewModel(this Domain.Entities.Users.User user)
        {
            return new UserDetailViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreateDate = user.CreateDate,
                //AvatarName = user.UserAvatar,
                IsActive = user.IsEmailActive,
                ActiveCode = user.EmailActiveCode,

            };
        }
        public static IQueryable<UserDetailViewModel> ToUserDetailViewModel(this IQueryable<Domain.Entities.Users.User> users)
        {
            return users.Select(user => user.ToUserDetailViewModel());
        }
        #endregion
        #region ToEditProfileViewModel


        public static EditProfileViewModel ToEditProfileViewModel(this Domain.Entities.Users.User user)
        {
            return new EditProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AvatarName = user.AvatarName



            };
        }
        public static IQueryable<EditProfileViewModel> ToEditProfileViewModel(this IQueryable<Domain.Entities.Users.User> users)
        {
            return users.Select(user => user.ToEditProfileViewModel());
        }
        #endregion
        #region ToAccountRegisterViewModel
        public static AccountRegisterViewModel ToAccountRegisterViewModel(this Domain.Entities.Users.User user)
        {
            return new AccountRegisterViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AvatarName = user.AvatarName,
                ActiveCode=user.EmailActiveCode,
                IsActive=user.IsEmailActive,
                Password=user.Password,
                CreateDate=user.CreateDate


            };
        }
        public static IQueryable<AccountRegisterViewModel> ToAccountRegisterViewModel(this IQueryable<Domain.Entities.Users.User> users)
        {
            return users.Select(user => user.ToAccountRegisterViewModel());
        }
        #endregion
        public static WalletViewModel ToWalletViewModel(this Domain.Entities.Wallet.Wallet wallet)
        {
            return new WalletViewModel
            {
            Amount=(int)wallet.Amount,
            Creatdate=wallet.CreatDate,
            Description=wallet.Description,
            UserId=wallet.UserId,
            Type= (int)(wallet.WalletType?.TypeId)


            };
        }
        public static IQueryable<WalletViewModel> ToWalletViewModel(this IQueryable<Domain.Entities.Wallet.Wallet> wallet)
        {
            return wallet.Select(wallet => wallet.ToWalletViewModel());
        }
        public static WalletHistoryViewModel ToWalletHistoryViewModel(this Domain.Entities.Wallet.Wallet wallet)
        {
            return new WalletHistoryViewModel
            {
                Amount = wallet.Amount,
                Creatdate = wallet.CreatDate,
                Description = wallet.Description,
                TypeId = wallet.WalletTypeId
            };
        }
        public static IQueryable<WalletHistoryViewModel> ToWalletHistoryViewModel(this IQueryable<Domain.Entities.Wallet.Wallet> wallet)
        {
            return wallet.Select(wallet => wallet.ToWalletHistoryViewModel());
        }
    }
}

