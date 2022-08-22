using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using CodeTo.Domain.Base;

namespace CodeTo.Domain.Entities.Articles
{
    public class Article : BaseEntity<long>, DateEntity
    {
       
        [Required]
        [MaxLength(150)]
        public string ArticleTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string Writer { get; set; }

        [Required]
        [MaxLength]
        public string ArticleDescription { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ShortDescription { get; set; }
        public string ArticleImageName { get; set; }
        public int VisitCount { get; set; } =1;

        #region Date

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations
        public List<ArticleComment> ArticleComment { get; set; }
        #endregion

    }
}
