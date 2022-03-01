using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;
using CodeTo.Core.ViewModel.CourseGroups;

namespace CodeTo.Core.Services.CourseServices
{
    public interface ICourseGroupService : IGenericService<int, CourseGroupIndexViewModel, CourseGroupCreateOrEditViewModel>
    {
    }
}
