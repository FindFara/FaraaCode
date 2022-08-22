using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.ViewModel.CourseGroups
{
    public class ClientCourseGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "اسم گروه")]
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
}
