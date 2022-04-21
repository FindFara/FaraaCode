using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    [BzDescription("ادمین")]
    public class DashboardController : AdminBaseController
    {
        [BzDescription("داشبورد")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
