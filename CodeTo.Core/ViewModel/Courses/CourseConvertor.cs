using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Courses;

namespace CodeTo.Core.ViewModel.Courses
{
   public  static class CourseConvertor
    {
        #region ToCreateOrEdit

        public static CourseCreateOrEditViewModel ToCreateOrEditViewModel(this Course course)
        {
            if (course == null) return null;
            return new CourseCreateOrEditViewModel
            {
                Id = course.Id,
                CourseTitle = course.CourseTitle,
                CoursePrice = course.CoursePrice,
                CourseDescription = course.CourseDescription,
                CourseImageName = course.CourseImageName,
                Tags = course.Tags,
                TeacherId = course.TeacherId,
                GroupId = course.GroupId
                
            };
        }

        public static IQueryable<CourseCreateOrEditViewModel> ToCreateOrEditViewModel(this IQueryable<Course> course)
        {
            return course.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion
        #region ToIndex

        public static CourseIndexViewModel ToIndexViewModel(this Course course)
        {
            if (course == null) return null;
            return new CourseIndexViewModel()
            {
                Id = course.Id,
                CourseTitle = course.CourseTitle,
                CoursePrice = course.CoursePrice,
                TeacherId = course.TeacherId,
                GroupId = course.GroupId,
                LastModifyDate =course.LastModifyDate
            };
        }
        public static IEnumerable<CourseIndexViewModel> ToIndexViewModel(this IEnumerable<Course> course)
        {
            return course.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<CourseIndexViewModel> ToIndexViewModel(this IQueryable<Course> course)
        {
            return course.Select(c => c.ToIndexViewModel());
        }

        #endregion
    }
}
