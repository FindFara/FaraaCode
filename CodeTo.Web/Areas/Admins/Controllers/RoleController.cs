using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.Services.PermiossionServices;
using CodeTo.Core.ViewModel.PermiossionViewModel;



namespace CodeTo.Web.Areas.Admins.Controllers
{
    public class RoleController : AdminBaseController
    {
        private readonly IPermiossionService _permiossion;

        public RoleController(IPermiossionService permiossion)
        {
            _permiossion = permiossion;
        }

        #region Roles Crud 

        [Route("ShowPermissions")]
        public async Task<IActionResult> ShowPermissions()
        {
            return View(await _permiossion.GetAllAsync());
        }

        [Route("AddRole")]
        public async Task<IActionResult> AddRole()
        {
            ViewData["permission"] =  _permiossion.GetAllPermissionAsync();
            return View();
        }
        [Route("AddRole")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(PermissionCreateorEditeViewModel model)
        {
            ViewData["permission"] = _permiossion.GetAllPermissionAsync();
            if (await _permiossion.DuplicateRoleAsync(model.Title))
            {
                ModelState.AddModelError("Title", "نام نقش تکراری است");
                return View(model);
            }

            var roleid = await _permiossion.AddRoleAsync(model);
            return RedirectToAction("ShowPermissions");
        }

        [Route("EditRole/{id}")]
        public IActionResult EditRole(byte id)
        {
            return View(_permiossion.ShowPermission(id));
        }

        [Route("EditRole/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(PermissionCreateorEditeViewModel model)
        {
            if (await _permiossion.DuplicateRoleAsync(model.Title))
            {
                ModelState.AddModelError("Title", "نام نقش تکراری است");
                return View(model);
            }

            await _permiossion.EditAsync(model);
            return RedirectToAction("ShowPermissions");
        }


        [Route("RemoveRole/{id}")]
        public IActionResult Remove(byte id)
        {
            return View( _permiossion.ShowPermission(id));
        }
        [Route("RemoveRole/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(PermissionCreateorEditeViewModel model)
        {
            await _permiossion.DeleteAsync(model.Id);
            return RedirectToAction("ShowPermissions");
        }

        [Route("Bo")]
        public IActionResult noclass()
        {
            return View();
        }
        #endregion
    }
}
