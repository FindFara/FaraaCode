using CodeTo.Core.Services.AdminPanelServices;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;
using CodeTo.Core.ViewModel.AdminPanel;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    [BzDescription("ادمین")]
    public class AdminHomeController : AdminBaseController
    {
        [BzDescription("داشبورد")]
        public IActionResult Index()
        {
            return View();
        }
      
    }
}