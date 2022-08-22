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

        public static ArticleCreateOrEditViewModel ToCreateOrEditViewModel(this Article article )
        {
            if (article == null) return null;
            return new ArticleCreateOrEditViewModel
            {
                Id = article.Id,
                Writer = article.Writer,
                ArticleTitle = article.ArticleTitle,
                ArticleDescription = article.ArticleDescription,
                CreateDate = article.CreateDate,
                ArticleImageName = article.ArticleImageName,
                ShortDescription= article.ShortDescription
                

            };
        }

        public static IQueryable<ArticleCreateOrEditViewModel> ToCreateOrEditViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion
        #region ToIndex

        public static ArticleIndexViewModel ToIndexViewModel(this Article article)
        {
            if (article == null) return null;
            return new ArticleIndexViewModel
            {
                Id = article.Id,
                Writer = article.Writer,
                ArticleTile = article.ArticleTitle,
                CreateDate = article.CreateDate,
                LastModifyDate = article.LastModifyDate,
                VisitCount = article.VisitCount
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

        public static ClientArticleViewModel ToClientArticleViewModel(this Article article)
        {
            if (article == null) return null;
            return new ClientArticleViewModel
            {
                Id = article.Id,
                Writer = article.Writer,
                ArticleTitle = article.ArticleTitle,
                ShortDescription= article.ShortDescription,
                ArticleDescription = article.ArticleDescription,
                CreateDate = article.CreateDate,
                ArticleImageName = article.ArticleImageName,
                VisitCount= article.VisitCount


            };
        }

        public static IQueryable<ClientArticleViewModel> ToClientArticleViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToClientArticleViewModel());
        }

        #endregion
        #region Article Comment

        public static ArticleCommentViewModel ToArticleCommentViewModel(this ArticleComment article)
        {
            if (article == null) return null;
            return new ArticleCommentViewModel
            {
                id = article.Id,
                UserId = article.UserId,
                ArticleId = article.ArticleId,
                Message = article.Message,
                ReaedAdmin = article.ReaedAdmin,
                CreateDate = article.CreateDate

            };
        }

        public static IQueryable<ArticleCommentViewModel> ToArticleCommentViewModel(this IQueryable<ArticleComment> ac)
        {
            return ac.Select(c => c.ToArticleCommentViewModel());
        }

        #endregion
    }
}
