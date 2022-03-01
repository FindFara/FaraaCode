using CodeTo.Core.Services.AdminPanelServices;
using CodeTo.Core.Services.PermiossionServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.AdminPanel;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    public class AdminHomeController : ArticleBaseController
    {
        private readonly IAdminPanelService _service;
        private readonly IPermiossionService _permiossion;

        public AdminHomeController(IAdminPanelService service, IPermiossionService permiossion)
        {
            _service = service;
            _permiossion = permiossion;
        }
        [Route("ApIndex")]
        public IActionResult Index()
        {
            return View();
        }

        #region Admin CRUD 
        [Route("UsersManagement")]
        public async Task<IActionResult> ShowAllUsers(int pageId = 1, string FilterEmail = "",
            string FilterUserName = "")
        {//ToDO:search buttom dose not work fix it
            return View(await _service.GetAllToShowAsync(pageId, FilterEmail, FilterUserName));
        }

        [Route("AddUserAp")]
        public async Task<IActionResult> AddUserFromAdmin()
        {
            ViewData["PermissionList"] = await _permiossion.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AddUserAp")]
        public async Task<IActionResult> AddUserFromAdmin(AdminPanelCreateOrEditViewModel model, List<byte> PermissionList)
        {
            ViewData["PermissionList"] = await _permiossion.GetAllAsync();

            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _service.IsEmailDuplicated(model.Email))
            {
                ModelState.AddModelError("Email", "ایمیل تکراری قابل ثبت نمی باشد");
                return View(model);
            }

            if (model.Title.Contains("admin,ادمین"))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نیست");
                return View(model);
            }
            if (await _service.IsUsernameDuplicated(model.Title))
            {
                ModelState.AddModelError("Title", "نام کاربری تکراری قابل ثبت نمی باشد");
                return View(model);
            }

            #endregion


            var userid = await _service.SecondAddAsync(model);
            await _permiossion.AddPermissionToUserAsync(PermissionList, userid);


            return RedirectToAction("ShowAllUsers", "AdminHome");
        }

        [Route("EditUserFromAdmin/{id}")]
        public async Task<IActionResult> EditUserFromAdmin(int id)
        {
            ViewData["PermissionList"] = await _permiossion.GetAllAsync();
            return View(await _service.ShowUserForEditAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EditUserFromAdmin/{id}")]
        public async Task<IActionResult> EditUserFromAdmin(AdminPanelCreateOrEditViewModel model, List<byte> PermissionList)
        {
            ViewData["PermissionList"] = await _permiossion.GetAllAsync();

            
            await _service.EditAsync(model);
            await _permiossion.EditPermissionToUserAsync(PermissionList, model.Id);
            return RedirectToAction("ShowAllUsers", "AdminHome");
        }
        //Todo Create delete view
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("ShowAllUsers", "AdminHome");
        }
        #endregion
        #region DeletedUsers
        [Route("ShowDeletedUsers")]
        public async Task<IActionResult> ShowDeletedUsers(int pageId = 1, string FilterEmail = "",
            string FilterUserName = "")
        {//ToDO:search buttom dose not work fix it
            return View(await _service.GetAllDeletedToShowAsync(pageId, FilterEmail, FilterUserName));
        }
        #endregion
    }

}
