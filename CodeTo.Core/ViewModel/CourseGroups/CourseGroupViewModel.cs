using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Articles;
using CodeTo.Domain.Entities.Courses;

namespace CodeTo.Core.ViewModel.CourseGroups
{
   public static class CourseGroupViewModel
    {
        #region ToCreateOrEdit

        public static CourseGroupCreateOrEditViewModel ToCreateOrEditViewModel(this CourseGroup group)
        {
            return new CourseGroupCreateOrEditViewModel
            {
                Id = group.Id,
                Title = group.GroupTitle,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate,
                IsDelete = group.IsDelete
            };
        }
        public static IQueryable<CourseGroupCreateOrEditViewModel> ToCreateOrEditViewModel(this IQueryable<CourseGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion
        #region ToIndex

        public static CourseGroupIndexViewModel ToIndexViewModel(this CourseGroup group)
        {
            return new CourseGroupIndexViewModel
            {
                Id = group.Id,
                Title = group.GroupTitle,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate,
                ParentId = group.ParentId
            };
        }
        public static IEnumerable<CourseGroupIndexViewModel> ToIndexViewModel(this IEnumerable<CourseGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<CourseGroupIndexViewModel> ToIndexViewModel(this IQueryable<CourseGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }

        #endregion
    }
}
