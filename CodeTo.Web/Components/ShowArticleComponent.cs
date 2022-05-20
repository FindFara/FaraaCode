using CodeTo.Core.Services.ArticleServices.ClientArticleServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Components
{
    public class ShowArticleComponent : ViewComponent
    {
        private readonly IClientArticleService _service;

        public ShowArticleComponent(IClientArticleService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(long id )
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Components/ShowArticle.cshtml", await _service.GetDetailArticle(id)));
        }
    }
}
