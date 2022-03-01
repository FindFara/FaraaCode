using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Base;

namespace CodeTo.Domain.Entities.Courses
{
    public class CourseStatus : BaseEntity<int>
    {
        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }
        public List<Course> Courses { get; set; }
    }
}
