using CodeTo.Core.Statics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.Articles
{
    public class ClientArticleViewModel
    {
        [Display(Name = "شناسه ")]
        public long Id { get; set; }
        [Display(Name = "شناسه گروه")]
        public int GroupId { get; set; }
        [Display(Name = "اسم گروه")]
        public string ArtileGroupTitle { get; set; }

        [Display(Name = "موضوع مقاله")]
        [Required(ErrorMessage = "Enter the {0}")]
        public string ArticleTitle { get; set; }
        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "لطفا{0}را کنید")]
        public string Writer { get; set; }

        [Display(Name = "توضیحات")]
        public string ArticleDescription { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public IFormFile ArticleImageFile { get; set; }
        public string ArticleImageName { get; set; }
        public string ArticleFullName =>
            !string.IsNullOrEmpty(ArticleImageName)
                ? $"{ArticlePathTools.ArticleImagePath}{ArticleImageName}"
                : ArticlePathTools.ArticleImageDefautl;
    }
}
