using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bz.ClassFinder.Attributes;
using CodeTo.Core.ViewModel.Articles;
using CodeTo.Web.Areas.Contents.Controllers;
using Microsoft.EntityFrameworkCore;
using CodeTo.Core.Services.ArticleServices.AdminArticle;

namespace CodeTo.Web.Areas.Contents.Controllers
{
    [BzDescription("نویسنده")]
    public class ArticleController : ContentBaseController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [BzDescription("مطالب")]
        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetAllAsync());
        }

        [BzDescription(" جزییات مطلب")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Admin/ArticleGroups/Create
        [BzDescription(" افزودن مطلب")]
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ArticleCreateOrEditViewModel());
        }

        // POST: Admin/ArticleGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription(" افزودن مطلب")]
        public async Task<IActionResult> Create(ArticleCreateOrEditViewModel article)
        {
            if (ModelState.IsValid)
            {
                await _articleService.AddAsync(article);
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        // GET: Admin/ArticleGroups/Edit/5
        [BzDescription(" ویرایش مطلب")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);
            if (article == null)
            {
                return NotFound();
            }

            return View("CreateOrEdit", article);
        }

        // POST: Admin/ArticleGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [BzDescription(" ویرایش مطلب")]
        public async Task<IActionResult> Edit(int id, ArticleCreateOrEditViewModel Article)
        {
            if (id != Article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleService.EditAsync(Article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _articleService.IsExist(Article.Id))
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

            return View("CreateOrEdit", Article);
        }

        // GET: Admin/ArticleGroups/Delete/5
        [BzDescription(" حذف مطلب")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Article = await _articleService.FindAsync(id.Value);
            if (Article == null)
            {
                return NotFound();
            }

            return View(Article);
        }

        // POST: Admin/ArticleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [BzDescription(" حذف مطلب")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _articleService.DeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
