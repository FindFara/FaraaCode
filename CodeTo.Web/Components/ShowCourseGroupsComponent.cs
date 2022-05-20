using CodeTo.Core.Services.ArticleServices;
using CodeTo.Core.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Components
{
    public class ShowCourseGroups : ViewComponent
    {
        private readonly ICourseGroupService _courseGroup;

        public ShowCourseGroups(ICourseGroupService courseGroup)
        {
            _courseGroup = courseGroup;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Components/ShowCourseGroups.cshtml", await _courseGroup.GetAllAsync()));
        }

    }
}
