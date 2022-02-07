using CodeTo.Core.Services.AccountVm;
using CodeTo.Core.ViewModel.User;
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

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

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
                    ModelState.AddModelError(nameof(vm.Password), "Email or Password not corect");

                if (ModelState.IsValid)
                {
                    var user = await _accountService.GetUserByEmailAsync(vm.Email);
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,"1"),
                    new Claim(ClaimTypes.Email,vm.Email)
                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = vm.RememberMe
                    };
                    await HttpContext.SignInAsync(principal, properties);

                    if (user.Id == 1)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                return View(vm);
            }


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
                    ModelState.AddModelError(nameof(vm.Email), "There is an email entered.");

                if (ModelState.IsValid)
                {
                    await _accountService.RegisterAsync(vm);
                    return RedirectToAction("Index", "Home");
                }
                return View(vm);
            }

            [Route("logout")]
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }

