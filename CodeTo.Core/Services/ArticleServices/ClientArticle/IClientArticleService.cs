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
        Task<IPagedList<ClientArticleViewModel>> GetAllToShowAsync(int pageId = 1, string FilterTitle= "");
        Task<ClientArticleViewModel> GetDetailArticle(long id);
        //Task<IPagedList<ClientArticleViewModel>> GetByGroupIdAsync(int groupid,int page = 1);
        Task<List<ClientArticleViewModel>> GetRecentArticle();

    }
}
