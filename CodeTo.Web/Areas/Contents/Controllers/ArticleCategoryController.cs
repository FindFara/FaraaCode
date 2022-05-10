using Microsoft.AspNetCore.Mvc;

namespace CodeTo.Web.Areas.Contents.Controllers
{
    public class ArticleCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
