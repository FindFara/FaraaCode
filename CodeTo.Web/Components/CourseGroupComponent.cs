using CodeTo.Core.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Views.Components
{
    public class CourseGroupComponent : ViewComponent
    {

        private readonly ICourseGroupService _Service;

        public CourseGroupComponent(ICourseGroupService service)
        {
            _Service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Components/CourseGroupComponent.cshtml", await _Service.GetAllGroup()));
        }
    }
}


