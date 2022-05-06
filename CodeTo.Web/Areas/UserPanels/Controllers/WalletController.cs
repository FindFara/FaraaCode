using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Accounts;
using CodeTo.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<IActionResult> Index(WalletHistoryViewModel wallet)
        {
            //How to use methods with different view models in one view
            
            if (ViewBag.ShowHistory != null)
            {
                ViewBag.ShowHistory =  _service.ShowHistory(User.Identity.Name);
            }
            return View(wallet);
        }

        [Route("Wallet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(WalletViewModel wallet)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowHistory = _service.ShowHistory(User.Identity.Name);
                if (wallet != null) return View(wallet);
            }

            //TODO:null rad shodan hs
            var walletid = _service.ChargeUserWallet(wallet.Amount, User.Identity.Name, "شارژ حساب ");

            #region OnlinePaymnet

                //Payment paymnet = new ZarinpalSandbox.Payment(Convert.ToInt32(wallet.Amount));
                //Task<PaymentRequestResponse> res = paymnet.PaymentRequest("شارژ حساب ", "https://localhost:44328/OnlinePayment" + walletid);
                //if (res.Result.Status == 100)
                //{
                //    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                //}
            

            #endregion

            return null;
        }
    }
}
