using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
