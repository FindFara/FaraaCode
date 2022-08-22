using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfaces;
using CodeTo.Core.ViewModel.CourseGroups;

namespace CodeTo.Core.Services.CourseServices
{
    public interface ICourseGroupService : IGenericService<int, CourseGroupIndexViewModel, CourseGroupCreateOrEditViewModel>
    {
        public Task<bool> IsSubGroup(int groupid);
        public Task<List<ClientCourseGroupViewModel>> GetAllGroup();
        public Task<List<ClientCourseGroupViewModel>> GetSubGroup(int groupid);
    }
}
