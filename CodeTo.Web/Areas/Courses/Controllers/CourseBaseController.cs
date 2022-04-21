using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Web.Attributes;

namespace CodeTo.Web.Areas.Courses.Controllers
{
    [Area("Courses")]
    [PermissionChecker]
    public class CourseBaseController : Controller { }
}
