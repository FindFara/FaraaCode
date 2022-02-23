using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Users;
using CodeTo.Web.Areas.UserPanel.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZarinpalSandbox;
using ZarinpalSandbox.Models;

namespace CodeTo.Web.Areas.UserPanels.Controllers
{
    public class WalletController : BaseUserPanelController
    {
        private  IUserPanelService _service;

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
                ViewBag.ShowHistory =  _service.ShowHistory(User.Identity.Name);
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
                Debug.Assert(User.Identity != null, "User.Identity != null");
                ViewBag.ShowHistory =  _service.ShowHistory(User.Identity.Name);
                if (wallet != null) return View(wallet);
            }


            Debug.Assert(wallet != null, nameof(wallet) + " != null");
            Debug.Assert(User.Identity != null, "User.Identity != null");
            
            var walletid = _service.ChargeUserWallet(wallet.Amount, User.Identity.Name, "شارژ حساب ");

            #region OnlinePaymnet

                Payment paymnet = new ZarinpalSandbox.Payment(Convert.ToInt32(wallet.Amount));
                Task<PaymentRequestResponse> res = paymnet.PaymentRequest("شارژ حساب ", "https://localhost:44328/OnlinePayment" + walletid);
                if (res.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                }
            

            #endregion

            return null;
        }
    }
}
