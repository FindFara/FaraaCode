using CodeTo.Core.Services.ArticleServices;
using CodeTo.Core.ViewModel.ArticleGroups;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeTo.Web.Components
{
    public class ShowArticleGroups : ViewComponent
    {
        private readonly IArticleGroupService _articleGroup;

        public ShowArticleGroups(IArticleGroupService articleGroup)
        {
            _articleGroup = articleGroup;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Components/ShowArticleGroups.cshtml", await _articleGroup.GetAllAsync()));
        }

    }
}
