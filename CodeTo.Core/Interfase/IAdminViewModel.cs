using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Interfase
{
    public interface IAdminIndexViewModel<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public interface IAdminCreateOrEditViewModel<TKey>
       where TKey : struct
    {
        public TKey Id { get; set; }
        //DateTime CreateDate { get; set; }        
    }
}
