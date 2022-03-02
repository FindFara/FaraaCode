using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;
using CodeTo.Core.Statics;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace CodeTo.Core.ViewModel.Courses
{
    public class CourseIndexViewModel : IIndexVeiwModel<int>
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int? CoursePrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }

    public class CourseCreateOrEditViewModel : ICreateOrEditeViewModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "شناسه گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupId { get; set; }

        [Display(Name = "شناسه استاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TeacherId { get; set; }
        
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseTitle { get; set; }

        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }

        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? CoursePrice { get; set; }

        [MaxLength(600)] 
        public string Tags { get; set; }

        public IFormFile CourseImageFile { get; set; }
        public string CourseImageName { get; set; }
        public string CourseFullName =>
            !string.IsNullOrEmpty(CourseImageName)
                ? $"{CoursePathTools.CourseImagePath}{CourseImageName}"
                : CoursePathTools.CourseImageDefautl;
    }
}
