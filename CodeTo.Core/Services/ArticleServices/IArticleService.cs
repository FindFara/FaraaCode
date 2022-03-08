using CodeTo.Core.ViewModel.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfaces;

namespace CodeTo.Core.Services.ArticleServices
{
    public interface IArticleService : IGenericService<long, ArticleIndexViewModel, ArticleCreateOrEditViewModel>
    {

    }

}
