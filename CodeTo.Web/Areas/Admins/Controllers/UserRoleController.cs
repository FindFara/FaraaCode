using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;
using CodeTo.Core.Services.PermissionServices;
using CodeTo.Core.ViewModel.Permission;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    public class UserRoleController : AdminBaseController
    {
        private readonly IPermissionService _permissionService;

        public UserRoleController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_permissionService.GetAllUserRole());
        }
        public async Task<IActionResult> Add()
        {
            return View("AddOrEdit", new UserRoleViewModel());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public async Task<IActionResult> Add(UserRoleViewModel ur)
        {
            if (ModelState.IsValid)
            {
                await _permissionService.AddUserRoleAsync(ur);
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", ur);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _permissionService.FindUserRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View("AddOrEdit", role );
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserRoleViewModel ur)
        {
            if (id != ur.UserRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _permissionService.UpdateUserRole(ur);
                }
                catch (Exception ex)
                {
                    if (!_permissionService.ExistsUserRole(ur.RoleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", ur);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _permissionService.FindUserRoleAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _permissionService.DeleteUserRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
