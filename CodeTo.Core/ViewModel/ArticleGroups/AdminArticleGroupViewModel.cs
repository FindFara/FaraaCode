using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfaces;

namespace CodeTo.Core.ViewModel.ArticleGroups
{
    public class ArticleGroupCreateOrEditViewModel : ICreateOrEditeViewModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "اسم گروه")]
        [Required(ErrorMessage = "Enter the {0}")]
        public string Title { get; set; }

        [Display(Name = "شناسه گروه اصلی")]
        public int? ParentId { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
       

    }

    public class ArticleGroupIndexViewModel:IIndexVeiwModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "اسم گروه")]
        public string Title { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "آخرین بروزرسانی")]
        public DateTime? LastModifyDate { get; set; }

        [Display(Name = "شناسه گروه ")]
        public int? ParentId { get; set; }
    }

}
