using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;

namespace CodeTo.Domain.Entities.Articles
{
   public class ArticleGroup : BaseEntity<int>, DateEntity
   {
       [Required]
       [MaxLength(50)]
       public string ArticleGroupTitle { get; set; }

       #region Auditable
       public DateTime CreateDate { get; set; }
       public DateTime? LastModifyDate { get; set; }

        #endregion
        public int? ParentID { get; set; }


        #region Relations
        [ForeignKey("ParentID")]
        public List<ArticleGroup> ArticleGroups { get; set; }
        public ICollection<Article> Article { get; set; }
       #endregion
   }
   
    
}
