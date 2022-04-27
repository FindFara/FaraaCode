using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.Services.CourseServices;
using CodeTo.Core.ViewModel.CourseGroups;
using CodeTo.Web.Areas.Contents.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Web.Areas.Contents.Controllers
{
    public class CourseGroupController : ContentBaseController
    {
        //private readonly ShopContext _context;
        private readonly ICourseGroupService _service;

        public CourseGroupController(ICourseGroupService service)
        {
            _service = service;
        }


        // GET: Admin/CourseGroups
       
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Admin/CourseGroups/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CourseGroup = await _service.FindAsync(id.Value);
            if (CourseGroup == null)
            {
                return NotFound();
            }

            return View(CourseGroup);
        }

        // GET: Admin/CourseGroups/Create
       
        public IActionResult Create()
        {
            return View("CreateOrEdit", new CourseGroupCreateOrEditViewModel());
        }

        // POST: Admin/CourseGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseGroupCreateOrEditViewModel CourseGroup)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(CourseGroup);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", CourseGroup);
        }

        // GET: Admin/CourseGroups/Edit/5
        [HttpGet("Courses/CourseGroup/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CourseGroup = await _service.FindAsync(id.Value);
            if (CourseGroup == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", CourseGroup);
        }

        // POST: Admin/CourseGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseGroupCreateOrEditViewModel CourseGroup)
        {
            if (id != CourseGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(CourseGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.IsExist(CourseGroup.Id))
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
            return View("CreateOrEdit", CourseGroup);
        }

        // GET: Admin/CourseGroups/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CourseGroup = await _service.FindAsync(id.Value);
            if (CourseGroup == null)
            {
                return NotFound();
            }

            return View(CourseGroup);
        }

        // POST: Admin/CourseGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool CourseGroupExists(int id)
        //{
        //    return _context.CourseGroups.Any(e => e.Id == id);
        //}
    }
}
