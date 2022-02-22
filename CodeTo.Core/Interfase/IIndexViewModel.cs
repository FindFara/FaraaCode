using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Interfase
{
    public interface IIndexVeiwModel<TKey>
    where TKey : struct
    {

        public TKey Id { get; set; }
    }
}