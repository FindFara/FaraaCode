using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Services.CourseServices;
using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.ViewModel.Articles;
using CodeTo.Core.ViewModel.Courses;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Core.Services.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly CodeToContext _context;
        private readonly ILoggerService<CourseService> _logger;

        public CourseService(CodeToContext context, ILoggerService<CourseService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<CourseCreateOrEditViewModel> FindAsync(int id)
        {
            var model = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<bool> AddAsync(CourseCreateOrEditViewModel vm)
        {

            try
            {
                string CourseImageName = null;
                if (vm.CourseImageFile != null)
                {
                    CourseImageName = GeneratorGuid.GeneratorUniqCode() + vm.CourseImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.CourseImageFile.AddImageToServer(CourseImageName, UserPathTools.UserImageServerPath, thumbSize,
                        vm.CourseImageName);
                }

                _context.Courses.Add(new Course
                {
                    Id = vm.Id,
                    CourseTitle = vm.CourseTitle,
                    CoursePrice = vm.CoursePrice,
                    CourseDescription = vm.CourseDescription,
                    GroupId = vm.GroupId,
                    LastModifyDate = DateTime.Now,
                    Tags = vm.Tags,
                    TeacherId = vm.TeacherId,
                    

                });

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(CourseCreateOrEditViewModel vm)
        {
            var Course = await _context.Courses.FindAsync(vm.Id);
            try
            {
                if (vm.CourseImageFile != null)
                {
                    var CourseImageName = DateTime.Now.ToString("MM-dd-yyyy_") + vm.CourseImageFile.FileName;
                    var thumbSize = new ThumbSize(100, 100);
                    vm.CourseImageFile.AddImageToServer(CourseImageName, CoursePathTools.CourseImageServerPath,
                        thumbSize, vm.CourseImageName);
                    Course.CourseImageName = CourseImageName;
                }

                Course.CourseTitle = vm.CourseTitle;
                Course.CoursePrice = vm.CoursePrice;
                Course.CourseDescription = vm.CourseDescription;
                Course.GroupId = vm.GroupId;
                Course.LastModifyDate = DateTime.Now;
                Course.Tags = vm.Tags;
                Course.TeacherId = vm.TeacherId;

                _context.Courses.Update(Course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _context.Courses.FindAsync(id);
                product.CourseImageName.DeleteImage(CoursePathTools.CourseImageServerPath);
                _context.Courses.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<CourseIndexViewModel>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.CourseGroup)
                .OrderByDescending(c => c.Id)
                .ToIndexViewModel()
                .ToListAsync();
        }

        public async
            Task<bool> IsExist(int id)
        {
            return await _context.Courses.AnyAsync(p => p.Id == id);
        }
    }
}
