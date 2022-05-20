using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Articles;

namespace CodeTo.Core.ViewModel.Articles
{
    public static class ArticleConvertor
    {
        #region ToCreateOrEdit

        public static ArticleCreateOrEditViewModel ToCreateOrEditViewModel(this Article Article)
        {
            if (Article == null) return null;
            return new ArticleCreateOrEditViewModel
            {
                Id = Article.Id,
                GroupId = Article.ArticleGroupId,
                Writer = Article.Writer,
                ArticleTitle = Article.ArticleTitle,
                ArticleDescription = Article.ArticleDescription,
                CreateDate = Article.CreateDate,
                ArticleImageName = Article.ArticleImageName

            };
        }

        public static IQueryable<ArticleCreateOrEditViewModel> ToCreateOrEditViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion
        #region ToIndex

        public static ArticleIndexViewModel ToIndexViewModel(this Article Article)
        {
            if (Article == null) return null;
            return new ArticleIndexViewModel
            {
                Id = Article.Id,
                Writer = Article.Writer,
                ArticleTile = Article.ArticleTitle,
                CreateDate = Article.CreateDate,
                LastModifyDate = Article.LastModifyDate
            };
        }
        public static IEnumerable<ArticleIndexViewModel> ToIndexViewModel(this IEnumerable<Article> Articles)
        {
            return Articles.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleIndexViewModel> ToIndexViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToIndexViewModel());
        }

        #endregion
        #region Client Index

        public static ClientArticleViewModel ToClientArticleViewModel(this Article Article)
        {
            if (Article == null) return null;
            return new ClientArticleViewModel
            {
                Id = Article.Id,
                GroupId = Article.ArticleGroupId,
                Writer = Article.Writer,
                ArticleTitle = Article.ArticleTitle,
                ArticleDescription = Article.ArticleDescription,
                CreateDate = Article.CreateDate,
                ArticleImageName = Article.ArticleImageName

            };
        }

        public static IQueryable<ClientArticleViewModel> ToClientArticleViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToClientArticleViewModel());
        }

        #endregion
        #region Article Comment

        public static ArticleCommentViewModel ToArticleCommentViewModel(this ArticleComment ac)
        {
            if (ac == null) return null;
            return new ArticleCommentViewModel
            {
                id = ac.Id,
                UserId = ac.UserId,
                ArticleId = ac.ArticleId,
                Message = ac.Message,
                ReaedAdmin = ac.ReaedAdmin,
                CreateDate = ac.CreateDate

            };
        }

        public static IQueryable<ArticleCommentViewModel> ToArticleCommentViewModel(this IQueryable<ArticleComment> ac)
        {
            return ac.Select(c => c.ToArticleCommentViewModel());
        }

        #endregion
    }
}
