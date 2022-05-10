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
        public int ArticleGroupId { get; set; }
        [Required]
        [MaxLength(150)]
        public string ArticleTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string Writer { get; set; }

        [Required]
        [MaxLength]
        public string ArticleDescription { get; set; }
        public string ArticleImageName { get; set; }

        #region Date

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations
        public ArticleGroup ArticleGroup { get; set; }
        public ICollection<ArticleComment> ArticleComment { get; set; }
        #endregion

    }
}
