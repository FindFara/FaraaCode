
using Bz.ClassFinder.Attributes;
using CodeTo.Core.Services.AccountServices;
using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Accounts;
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
    public class UserPanelHomeController : BaseUserPanelController
    {
        private IUserPanelService _userpanel;
        public UserPanelHomeController(IUserPanelService userpanel)
        {
            _userpanel = userpanel;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(await _userpanel.GetUserInformation(User.Identity.Name));
        }
        #endregion

        #region EditProfile

        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            return View(await _userpanel.GetEditProfileData(User.Identity.Name));
        }

        [Route("EditProfile")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string username, EditProfileViewModel profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

           await _userpanel.EditProfile(User.Identity.Name, profile);

        
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","Account");
        }
        #endregion
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [Route("ChangePassword")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel change)
        {
            var username = User.Identity.Name;
            var pass = change.OldPassword;
            if (!ModelState.IsValid)
            {
                return View(change);
            }
            if (!await _userpanel.compareOldPassword(username, pass))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد !");
                return View(change);
            }

             await _userpanel.ChangePassword(username, change.Password);

            return Redirect("auth/Login");
        }
    }
}