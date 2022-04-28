using CodeTo.Core.Services.AccountServices;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Senders;
using CodeTo.Core.ViewModel.Accounts;
using CodeTo.Domain.Entities.Users;
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
        public async Task<IActionResult> Login(AccountLoginViewModel register)
        {
            if (!await _accountService.CheckEmailAndPasswordAsync(register))
                ModelState.AddModelError(nameof(register.Password), "ایمیل یا پسورد وارد شده معتبر نمیباشد ");

            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmailAsync(register.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = register.RememberMe
                };
                await HttpContext.SignInAsync(principal,properties);

                    return RedirectToAction("Index", "Home");

            }
            return View(register);
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
        public async Task<IActionResult> Register(AccountRegisterViewModel register)
        {
            

            if (await _accountService.IsDuplicatedEmail(register.Email))
                ModelState.AddModelError(nameof(register.Email), "ایمیل ورودی معتبر نمیباشد ");

            if (await _accountService.IsDuplicatedUsername(register.UserName))
                ModelState.AddModelError(nameof(register.UserName), "نام کاربری  ورودی معتبر نمیباشد ");


            if (!ModelState.IsValid)
            {
                return View(register);
            }

             var user = await _accountService.RegisterAsync(register);
           

            //TODO: Activation Send Email
            //TODO: Redirect to succssesfullView

            return RedirectToAction("Login", "Account");
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

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}

