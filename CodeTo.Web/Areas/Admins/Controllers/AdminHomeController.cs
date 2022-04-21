using CodeTo.Core.Services.AdminPanelServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;
using CodeTo.Core.ViewModel.AdminPanel;

namespace CodeTo.Web.Areas.Admins.Controllers

{
    [BzDescription("کاربران")]
    public class AdminHomeController : AdminBaseController
    {
        private readonly IAdminPanelService _service;

        public AdminHomeController(IAdminPanelService service)
        {
            _service = service;
        }
        [BzDescription("لیست کاربران")]
        public async Task<IActionResult> Index(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {

            return View(await _service.GetAllToShowAsync(pageId, FilterEmail, FilterUserName));

        }
        [BzDescription("افزودن کاربر")]
        public async Task<IActionResult> Add()
        {
            return View("AddOrEdit", new AdminPanelCreateOrEditViewModel());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription("افزودن کاربر")]
        public async Task<IActionResult> Add(AdminPanelCreateOrEditViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", user);
        }
        // GET
        [BzDescription("جزییات کاربر")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _service.FindAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET
        [BzDescription("ویرایش کاربر")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _service.FindAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View("AddOrEdit", user);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription("ویرایش کاربر")]
        public async Task<IActionResult> Edit(int id, AdminPanelCreateOrEditViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(user);
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", user);
        }

        // GET
        [BzDescription("حذف کاربر")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _service.FindAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [BzDescription("حذف کاربر")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


