using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.Accounts
{
    public class WalletChargeViewModel
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید !")]
        public double Amount { get; set; }
    }

    public class WalletHistoryViewModel
    {
        public int? Amount { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public DateTime Creatdate { get; set; }
    }

    public class WalletViewModel
    {
        public int Amount { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public DateTime Creatdate { get; set; }
        public int UserId { get; set; }
    }
}
