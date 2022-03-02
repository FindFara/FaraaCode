using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.Services.ArticleServices;
using CodeTo.Core.ViewModel.ArticleGroups;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Web.Areas.Articles.Controllers
{
    public class ArticleGroupController :ArticleBaseController
    {
        //private readonly ShopContext _context;
        private readonly IArticleGroupService _service;

        public ArticleGroupController(IArticleGroupService service)
        {
            _service = service;
        }


        // GET: Admin/ArticleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Admin/ArticleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _service.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }

            return View(articleGroup);
        }

        // GET: Admin/ArticleGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ArticleGroupCreateOrEditViewModel());
        }

        // POST: Admin/ArticleGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleGroupCreateOrEditViewModel articleGroup)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(articleGroup);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", articleGroup);
        }

        // GET: Admin/ArticleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _service.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", articleGroup);
        }

        // POST: Admin/ArticleGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleGroupCreateOrEditViewModel articleGroup)
        {
            if (id != articleGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(articleGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.IsExist(articleGroup.Id))
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
            return View("CreateOrEdit", articleGroup);
        }

        // GET: Admin/ArticleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleGroup = await _service.FindAsync(id.Value);
            if (articleGroup == null)
            {
                return NotFound();
            }

            return View(articleGroup);
        }

        // POST: Admin/ArticleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ArticleGroupExists(int id)
        //{
        //    return _context.ArticleGroups.Any(e => e.Id == id);
        //}
    }
}
