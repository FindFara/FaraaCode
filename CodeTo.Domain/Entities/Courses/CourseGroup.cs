using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;

namespace CodeTo.Domain.Entities.Courses
{
    public class CourseGroup : BaseEntity<int>,DateEntity
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }


        [InverseProperty("CourseGroup")]
        public List<Course> Courses { get; set; }
       

        #region Date

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion
    }


}
