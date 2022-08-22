using CodeTo.Core.Services.ArticleServices.ClientArticleServices;
using CodeTo.Core.Services.CommentService.ArticleComment;
using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Articles;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Articles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeTo.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IClientArticleService _service;
        private readonly IArticleCommentService _articleComment;
        private readonly IUserPanelService _userPanel;
        public BlogController(IArticleCommentService articleComment, IClientArticleService service)
        {
            _articleComment = articleComment;
            _service = service;
        }

        public async Task<IActionResult> Index(int groupid, int pageId = 1, string FilterTitle = "")
        {
            var AllArticle = await _service.GetAllToShowAsync(pageId, FilterTitle);
            return View(AllArticle);
            //return View(Tuple.Create(AllArticle,ByGroup));
        }
        [HttpGet]
        public async Task<IActionResult> DetailArticle(long id)
        {
            return View(await _service.GetDetailArticle(id));

        }

        // POST
        [HttpPost]
        public async Task<IActionResult> CreateComment(ArticleCommentViewModel comment, int articleid)
        {
            //TODO : send comment not work
            if (ModelState.IsValid)
            {
                await _articleComment.AddCommentAsync(comment, User.Identity.Name);

                return View("DetailArticle");
            }
            return View("Blog/DetailArticle");

        }

    }
}
