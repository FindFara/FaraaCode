
using CodeTo.Core.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelController
    {
        private IAccountService accountServise;
        public HomeController(IAccountService _accountServise)
        {
            accountServise = _accountServise;
        }
        public async Task<IActionResult> Index()
        {
            return View(await accountServise.GetUserInformation(User.Identity.Name));
        }
    }
}
