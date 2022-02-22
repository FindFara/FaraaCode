using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Domain.Entities.Wallet
{
   public class WalletType
   {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Type { get; set; }
        


        #region 
        public List<Wallet> Wallets { get; set; }
        #endregion
    }
}
