using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.Services.CourseServices;
using CodeTo.Core.ViewModel.Courses;
using CodeTo.Web.Areas.Courses.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Web.Areas.Courses.Controllers
{
    public class CourseController : CourseBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGroup = await _courseService.FindAsync(id.Value);
            if (bookGroup == null)
            {
                return NotFound();
            }

            return View(bookGroup);
        }

        // GET: Admin/courseGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new CourseCreateOrEditViewModel());
        }

        // POST: Admin/courseGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateOrEditViewModel course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddAsync(course);
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // GET: Admin/courseGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.FindAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View("CreateOrEdit", course);
        }

        // POST: Admin/courseGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseCreateOrEditViewModel course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _courseService.EditAsync(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _courseService.IsExist(course.Id))
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

            return View("CreateOrEdit", course);
        }

        // GET: Admin/courseGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.FindAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Admin/courseGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

