using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeTo.Domain.Entities.Users;
using System.Threading.Tasks;
using CodeTo.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace CodeTo.Domain.Entities.Wallet
{
   public class Wallet : BaseEntity<long>
   {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public double Amount { get; set; }
        [Display(Name = "شرح")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }
        [Display(Name = "تایید شده")]
        public bool ISpay { get; set; }
        [Display(Name = "تاریخ و ساعت")]
        public DateTime CreatDate { get; set; }


        #region Relation
        public WalletType WalletType { get; set; }
        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public byte WalletTypeId { get; set; }

        public User User { get; set; }
        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }
        #endregion

    }
}