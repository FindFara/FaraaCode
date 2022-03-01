using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;
using CodeTo.Core.ViewModel.ArticleGroups;

namespace CodeTo.Core.Services.ArticleServices
{
    public interface IArticleGroupService : IGenericService<int, ArticleGroupIndexViewModel, ArticleGroupCreateOrEditViewModel>
    {
    }
}
