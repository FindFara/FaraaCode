using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.ArticleGroups;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Articles;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Core.Services.ArticleServices
{
   public class ArticleGroupService :IArticleGroupService
    {
        private readonly CodeToContext _context;

        public ArticleGroupService(CodeToContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArticleGroupCreateOrEditViewModel vm)
        {
            try
            {
                _context.ArticleGroups.Add(new ArticleGroup
                {
                    Id = vm.Id,
                    CreateDate = DateTime.Now,
                    ArticleGroupTitle = vm.Title
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var ArticleGroup = await _context.ArticleGroups.FindAsync(id);
                _context.ArticleGroups.Remove(ArticleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(ArticleGroupCreateOrEditViewModel vm)
        {
            try
            {
                var ArticleGroup = await _context.ArticleGroups.FindAsync(vm.Id);
                ArticleGroup.ArticleGroupTitle = vm.Title;
                ArticleGroup.LastModifyDate = DateTime.Now;
                _context.ArticleGroups.Update(ArticleGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.ArticleGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<ArticleGroupCreateOrEditViewModel> FindAsync(int id)
        {
            var model = await _context.ArticleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ArticleGroupIndexViewModel>> GetAllAsync()
        {
            return await _context.ArticleGroups.ToIndexViewModel().ToListAsync();
            //var result = await _context.ArticleGroups.ToListAsync();
            //var vm = result.ToIndexViewModel().ToList();
            //return vm;
        }
    }
}
