using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Users;
using CodeTo.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTo.Web.Areas.UserPanels.Controllers
{
    public class WalletController : BaseUserPanelController
    {
        private readonly IUserPanelService _service;

        public WalletController(IUserPanelService service)
        {
            service = _service;
        }

        [Route("Wallet")]
        public async Task<IActionResult> Index()
        {
            //How to use methods with different view models in one view
            if (ViewBag.ShowHistory != null)
            {
                ViewBag.ShowHistory = await _service.ShowHistory(User.Identity.Name);
            }
            return View();
        }

        [Route("Wallet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(WalletViewModel wallet)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowHistory = await _service.ShowHistory(User.Identity.Name);
                return View(wallet);
            }

            var walletid = _service.ChargeUserWallet(wallet.Amount, User.Identity.Name, "شارژ حساب ");

            #region OnlinePaymnet

            var paymnet = new ZarinpalSandbox.Payment(Convert.ToInt32(wallet.Amount));
            var res = paymnet.PaymentRequest("شارژ حساب ", "https://localhost:44328/OnlinePayment" + walletid);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            #endregion

            return null;
        }
    }
}
