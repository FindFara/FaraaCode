using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfaces;
using CodeTo.Core.ViewModel.ArticleGroups;
using CodeTo.Core.ViewModel.Articles;
using CodeTo.Core.ViewModel.CourseGroups;

namespace CodeTo.Core.Services.ArticleServices
{
    public interface IArticleGroupService : IGenericService<int, ArticleGroupIndexViewModel, ArticleGroupCreateOrEditViewModel>
    {
       
    }
}
