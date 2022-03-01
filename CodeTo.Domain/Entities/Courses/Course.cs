using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;
using CodeTo.Domain.Entities.Users;

namespace CodeTo.Domain.Entities.Courses
{
    public class Course : BaseEntity<int>, DateEntity
    {
        [Required]
        public int GroupId { get; set; }

        [Required] 
        public int TeacherId { get; set; }

        [Required] 
        public int StatusId { get; set; }

        [Required]
        public int LevelId { get; set; }

        public int? SubGroup { get; set; }

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

        [MaxLength(100)]
        public string CourseImageName { get; set; }


        #region Date

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        #endregion
        #region Relations
        public CourseStatus CourseStatus { get; set; }
        public CourseLevel CourseLevel { get; set; }

        [ForeignKey("TeacherId")] 
        public Users.User User { get; set; }

        [ForeignKey("GroupId")]
        public CourseGroup CourseGroup { get; set; }

        [ForeignKey("SubGroup")]
        public CourseGroup Group { get; set; }

        #endregion

    }
}
