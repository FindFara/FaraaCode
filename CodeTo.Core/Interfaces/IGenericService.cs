using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Interfaces
{
    // we use this interface to make our viewModels in same order and avoid any conflict 
    //the main reason to use this Interface is CRUD
    //This is not essential but that make your code more professional 
    //Our services must inharitace from IGenericInterfac and then we should make view models which inharited from IINdex or ICreateOrEdit
    public interface IGenericService<TKey, TIndex, TCreateOrEdit>
    where TKey : struct
    where TIndex : IIndexVeiwModel<TKey>
    where TCreateOrEdit : ICreateOrEditeViewModel<TKey>
    {
        Task<TCreateOrEdit> FindAsync(TKey id);
        Task<bool> AddAsync(TCreateOrEdit vm);
        Task<bool> EditAsync(TCreateOrEdit vm);
        Task<bool> DeleteAsync(TKey id);
        Task<List<TIndex>> GetAllAsync();
        Task<bool> IsExist(TKey id);
    }
}
