using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Domain.Base
{
   public  interface IDateEntity
    {
        DateTime RegisterDate { get; set; }
        DateTime? LastModifyDate { get; set; }
    }
}
