using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseAdminController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
