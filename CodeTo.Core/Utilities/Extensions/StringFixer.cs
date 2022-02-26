using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Utilities.Extensions
{
   public static class StringFixer
    {
        public static string Fixer(this string fix)
        {
            if (!string.IsNullOrEmpty(fix))
                fix = fix.ToLower().Trim();
            return fix;
        }
    }
}
