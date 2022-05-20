using CodeTo.Core.ViewModel.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace CodeTo.Core.Services.ArticleServices.ClientArticleServices
{
    public interface IClientArticleService
    {
        public Task<IPagedList<ClientArticleViewModel>> GetAllToShowAsync(int pageId = 1, string FilterTitle= "");
        public Task<ClientArticleViewModel> GetDetailArticle(long id);
        Task<IPagedList<ClientArticleViewModel>> GetByGroupIdAsync(int groupid,int page = 1);
    }
}
