using CodeTo.Core.ViewModel.Users;
using System.IO;

namespace CodeTo.Core.Statics
{
    public static class PathTools
    {
        public static string UserImageDefautl = "/images/UserAvatar/default-user.jpg";
        public static string UserImagePath = "/upload/user/";
        public static string UserImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{UserImagePath}");

        public static string GeneratorImageName(this string imagename)
        {
            return
             !string.IsNullOrEmpty(imagename)
             ? $"{PathTools.UserImagePath}{imagename}"
             : PathTools.UserImageDefautl;
        }

    }
}