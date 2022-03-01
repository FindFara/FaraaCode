using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTo.Core.Services.ArticleServices;

namespace CodeTo.Web.Areas.Articles.Controllers
{
    public class ArticleController : ArticleBaseController
    {
        private readonly IArticleService _Service;

        public ArticleController(IArticleService Service)
        {
            _Service = Service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Service.GetAllAsync());
        }
    }
}