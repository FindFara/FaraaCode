using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bz.ClassFinder.Models;

namespace CodeTo.Core.Statics
{
   public class Values
    {
       public const int PageSize = 15;
        public const int BlogPageSize = 12;
        public static List<BzClassInfo> Permissions
       {
           get
           {
               var permission = Bz.ClassFinder.Helper
                   .GetClassAndMethods(Path.Combine(
                       Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "CodeTo.Web.dll"))
                   .ToList();
               //permission.Add(_otherBzClassInfo);

               return permission.Where(c => c.Methods.Any()).OrderBy(c => c.FullName).ToList();
           }
       }
       //private static readonly BzClassInfo _otherBzClassInfo = new BzClassInfo() { };
    }
}
