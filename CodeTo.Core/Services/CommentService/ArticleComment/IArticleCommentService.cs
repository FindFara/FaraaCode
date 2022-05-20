using CodeTo.Core.ViewModel.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.CommentService.ArticleComment
{
    public interface IArticleCommentService
    {
        Task<bool> AddCommentAsync(ArticleCommentViewModel comment, string username);
        Task<List<ArticleCommentViewModel>> GetCommentsAsync(int Articleid);
    }
}
