using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.CourseGroups;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Core.Services.CourseServices
{
    public class CourseGroupService : ICourseGroupService
    {
        private readonly CodeToContext _context;

        public CourseGroupService(CodeToContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(CourseGroupCreateOrEditViewModel vm)
        {
            try
            {
                _context.CourseGroups.Add(new CourseGroup
                {
                    Id = vm.Id,
                    CreateDate = DateTime.Now,
                    GroupTitle = vm.Title
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
                var CourseGroup = await _context.CourseGroups.FindAsync(id);
                _context.CourseGroups.Remove(CourseGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(CourseGroupCreateOrEditViewModel vm)
        {
            try
            {
                var CourseGroup = await _context.CourseGroups.FindAsync(vm.Id);
                CourseGroup.GroupTitle = vm.Title;
                CourseGroup.LastModifyDate = DateTime.Now;
                _context.CourseGroups.Update(CourseGroup);
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
            return await _context.CourseGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<CourseGroupCreateOrEditViewModel> FindAsync(int id)
        {
            var model = await _context.CourseGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<CourseGroupIndexViewModel>> GetAllAsync()
        {
            return await _context.CourseGroups.ToIndexViewModel().ToListAsync();
            //var result = await _context.CourseGroups.ToListAsync();
            //var vm = result.ToIndexViewModel().ToList();
            //return vm;
        }
    }
}
