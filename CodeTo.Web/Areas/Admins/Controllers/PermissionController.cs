using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;
using CodeTo.Core.Services.PermissionServices;
using CodeTo.Core.Statics;
using CodeTo.Core.ViewModel.Permission;
using CodeTo.DataEF.Context;

namespace CodeTo.Web.Areas.Admins.Controllers
{
    [BzDescription("مدیریت نقش ها")]
    public class PermissionController : AdminBaseController
    {
        private readonly IPermissionService _permissionService;
        private readonly CodeToContext _context;
        public PermissionController(IPermissionService permissionService, CodeToContext context)
        {
            _permissionService = permissionService;
            _context = context;
        }

        // GET
        [BzDescription("دسترسی")]
        public async Task<IActionResult> Index()
        {
            return View(  _permissionService.GetAllRoles());
        }

        // GET
        [BzDescription("جزییات دسترسی")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        //TODO:put the therd parametr for the user to seeonly the relevant section
        [BzDescription("افزودن دسترسی")]
        public async Task<IActionResult> Add()
        {
            var Permissions = await _permissionService.GetAllPermission();
            return View("AddOrEdit", Tuple.Create(new RolePermissionAddOrEditViewModel(), Permissions)); 
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription("افزودن دسترسی")]
        public async Task<IActionResult> Add(RolePermissionAddOrEditViewModel role)
        {
            var Permissions =await _permissionService.GetAllPermission();
            if (ModelState.IsValid)
            {
                await _permissionService.AddRoleAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit",role);

        }

        // GET
        [BzDescription("ویرایش دسترسی")]
        public async Task<IActionResult> Edit(int? id)
        {
            var Permissions = await _permissionService.GetAllPermission();
            if (id == null)
            {
                return NotFound();
            }
            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View("AddOrEdit",Tuple.Create( role,Permissions));
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription("ویرایش دسترسی")]
        public async Task<IActionResult> Edit(int id, RolePermissionAddOrEditViewModel role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _permissionService.UpdateRole(role);
                }
                catch (Exception ex)
                {
                    if (!_permissionService.ExistsRole(role.RoleId))
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
            return View("AddOrEdit", role);
        }

        // GET
        [BzDescription("حذف دسترسی")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _permissionService.FindRoleAsync(id.Value);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [BzDescription("حذف دسترسی")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _permissionService.RemoveRoleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

