
using Bz.ClassFinder.Attributes;
using CodeTo.Core.Services.AccountServices;
using CodeTo.Core.ViewModel.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelController
    {
        private IAccountService _accountServise;
        public HomeController(IAccountService accountServise)
        {
            _accountServise = accountServise;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _accountServise.GetUserInformation(User.Identity.Name));
        }

        #region EditProfile

        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            return View(await _accountServise.GetEditPrifileData(User.Identity.Name));
        }

        [Route("EditProfile")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string username, EditProfileVm profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

           await _accountServise.EditProfile(User.Identity.Name, profile);

            //Log Out User
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("auth/Login?EditProfile=true");
        }
        #endregion
    }
}