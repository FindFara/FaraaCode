using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Utilities.Extension
{
   public static class GeneratorGuid
    {
        public static string GeneratorUniqCode()
        {
            return Guid.NewGuid().ToString().Replace(" ", "-");
        }
    }
}
