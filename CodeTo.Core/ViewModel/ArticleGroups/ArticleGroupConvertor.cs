using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Articles;

namespace CodeTo.Core.ViewModel.ArticleGroups
{
    public static class ArticleGroupConvertor
    {
        public static ArticleGroupCreateOrEditViewModel ToCreateOrEditViewModel(this ArticleGroup group)
        {
            return new ArticleGroupCreateOrEditViewModel
            {
                CreateDate = group.CreateDate,
                Id = group.Id,
                Title = group.ArticleGroupTitle,
                ParentId = group?.ParentID

            };
        }
        public static IQueryable<ArticleGroupCreateOrEditViewModel> ToCreateOrEditViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }

        public static ArticleGroupIndexViewModel ToIndexViewModel(this ArticleGroup group)
        {
            return new ArticleGroupIndexViewModel
            {
                Id = group.Id,
                Title = group.ArticleGroupTitle,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate,
                ParentId = group?.ParentID
                
            };
        }
        public static IEnumerable<ArticleGroupIndexViewModel> ToIndexViewModel(this IEnumerable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleGroupIndexViewModel> ToIndexViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
    }
}
