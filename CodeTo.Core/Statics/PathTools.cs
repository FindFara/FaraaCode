using CodeTo.Core.ViewModel.Accounts;
using System.IO;

namespace CodeTo.Core.Statics
{
    public static class UserPathTools
    {
        public static string UserImageDefautl = "/images/UserImages/default-user.jpg";
        public static string UserImagePath = "/upload/user/";
        public static string UserImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{UserImagePath}");

    }
    public static class ArticlePathTools
    {
        public static string ArticleImageDefautl = "/images/ArticleImages/default-article.jpg";
        public static string ArticleImagePath = "/upload/article/";
        public static string ArticleImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{ArticleImagePath}");

    }
    public static class CoursePathTools
    {
        public static string CourseImageDefautl = "/images/CourseImages/default-course.jpg";
        public static string CourseImagePath = "/upload/course/";
        public static string CourseImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{CourseImagePath}");

    }
}