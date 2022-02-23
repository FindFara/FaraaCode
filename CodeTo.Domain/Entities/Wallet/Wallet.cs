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
    public class Wallet : BaseEntity<int>
    {
    
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool Ispay { get; set; }
        public DateTime CreatDate { get; set; }

        #region Relation
        public WalletType WalletType { get; set; }
        public int WalletTypeId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        #endregion

    }
}