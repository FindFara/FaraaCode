using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.Articles
{
    public class ArticleCommentViewModel
    {
        public long id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public bool ReaedAdmin { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
