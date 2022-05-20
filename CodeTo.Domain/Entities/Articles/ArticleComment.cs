using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Domain.Entities.Articles
{
    public class ArticleComment : BaseEntity<long>
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public bool ReaedAdmin { get; set; }

        [Required] [MaxLength(500)] 
        public string Message { get; set; }

        #region Date
        public DateTime CreateDate { get; set; }
        #endregion
        #region Relations

        public Article Article { get; set; }
        public User User { get; set; }

        #endregion
    }

}
