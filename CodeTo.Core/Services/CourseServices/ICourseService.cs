using CodeTo.Core.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.Courses;

namespace CodeTo.Core.Services.CourseServices
{
    public interface ICourseService : IGenericService<int, CourseIndexViewModel, CourseCreateOrEditViewModel>
    {
    }
}
