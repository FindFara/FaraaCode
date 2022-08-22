using CodeTo.Core.Services.ArticleServices.ClientArticleServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Components
{
    public class ShowRecentArticlesComponent : ViewComponent
    {
        private readonly IClientArticleService _articleService;

        public ShowRecentArticlesComponent(IClientArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Components/ShowRecentArticlesComponent.cshtml", await _articleService.GetRecentArticle()));
        }
    }
}
