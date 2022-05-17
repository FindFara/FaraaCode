using CodeTo.Core.Services.ArticleServices.ClientArticleServices;
using CodeTo.DataEF.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Controllers
{
    public class BlogController : Controller
    {
        public readonly IClientArticleService _service;

        public BlogController(IClientArticleService service)
        {
            _service = service;
        }
   
        public async Task<IActionResult> Index(int pageId = 1, string FilterTitle = "")
        {
            return View(await _service.GetAllToShowAsync(pageId,FilterTitle));
        }
        public async Task<IActionResult> DetailArticle(long id)
        {
                return View(await _service.GetDetailArticle(id));
        }
    }
}
