using CodeTo.Core.Services.AccountVm;
using CodeTo.Core.Utilities.Extension;
using CodeTo.Core.Utilities.Senders;
using CodeTo.Core.ViewModel.User;
using CodeTo.Domain.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeTo.Web.Controllers
{

    [Route("auth")]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private IViewRenderService viewRenderService;

        public AccountController(IAccountService accountService, IViewRenderService viewRenderService)
        {
            _accountService = accountService;
            this.viewRenderService = viewRenderService;
        }



        #region Login
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginVm vm)
        {
            if (!await _accountService.CheckEmailAndPasswordAsync(vm))
                ModelState.AddModelError(nameof(vm.Password), "ایمیل یا پسورد وارد شده معتبر نمیباشد ");

            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmailAsync(vm.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserName.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = vm.RememberMe
                };
                await HttpContext.SignInAsync(principal,properties);

                    return RedirectToAction("Index", "Home");

            }
            return View(vm);
        }
        #endregion

        #region Register
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterVm vm)
        {
            if (await _accountService.IsDuplicatedEmail(vm.Email))
                ModelState.AddModelError(nameof(vm.Email), "ایمیل ورودی معتبر نمیباشد ");

            

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

             var user = await _accountService.RegisterAsync(vm);
           

            #region Send Activation Email

            string body = viewRenderService.RenderToStringAsync("_ActiveEmail",User);
            SendEmail.Send(vm.Email, "فعالسازی", body);

            #endregion




            return View("SuccessRegister",user);
        }
        #endregion

        #region Active Account
        public async Task<IActionResult> ActiveAccount(string id)
        {
            ViewBag.IsActiv = await _accountService.ActiveAccountAsync(id);
            return View();
        }

        #endregion

        #region Logout
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }

}

