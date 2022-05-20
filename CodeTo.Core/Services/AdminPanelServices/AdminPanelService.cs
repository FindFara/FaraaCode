using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Statics;
using CodeTo.Core.Utilities.Extensions;
using CodeTo.Core.Utilities.Security;
using CodeTo.Core.ViewModel.AdminPanel;
using CodeTo.Core.ViewModel.Permission;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CodeTo.Core.Services.AdminPanelServices
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly CodeToContext _context;
        private readonly ISecurityService _security;

        public AdminPanelService(CodeToContext context, ISecurityService security)
        {
            _context = context;
            _security = security;
        }
        public async Task<AdminPanelCreateOrEditViewModel> FindAsync(int id)
        {

            var model = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            return model.ConvertorAdminPanelCreatOrEditViewModel();
        }

        public async Task<int> SecondAddAsync(AdminPanelCreateOrEditViewModel vm)
        {

            var email = StringFixer.Fixer(vm.Email);
            var username = StringFixer.Fixer(vm.UserName);
            var pass = _security.HashPassword(vm.Password);
            User adduser = new User();
            adduser.CreateDate = DateTime.Now;
            adduser.Email = email;
            adduser.Password = pass;
            adduser.UserName = username;
            adduser.EmailActiveCode = GeneratorGuid.GeneratorUniqCode();
            adduser.IsBlocked = false;
            adduser.IsEmailActive = true;
            adduser.LastModifyDate = DateTime.Now;
            #region save pic

            if (vm.AvatarFile != null)
            {
                var imagepath = "";
                adduser.AvatarImageName = "pic" + GeneratorGuid.GeneratorUniqCode() + Path.GetExtension(vm.AvatarFile.FileName);
                imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile",
                    adduser.AvatarImageName);
                await using (var stream = new FileStream(imagepath, FileMode.Create))
                {
                    vm.AvatarFile.CopyTo(stream);
                }

            }


            #endregion
            _context.Users.Add(adduser);
            await _context.SaveChangesAsync();
            return adduser.Id;




        }

        public async Task<AdminPanelIndexViewModel> GetAllDeletedToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {//Todo :list is not work appropriate 
            IEnumerable<AdminPanelIndexViewModel> result = _context.Users.ConvertorAdminPanelIndexViewModel().IgnoreQueryFilters().Where(u => u.IsDelete);
            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail)).ToList();
            }

            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));
            }

            //take shows in each page
            int take = 20;
            int skip = (pageId - 1) * take;

            AdminPanelIndexViewModel list = new AdminPanelIndexViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.users = _context.Users.OrderBy(u => u.CreateDate).ConvertorAdminPanelIndexViewModel().Skip(skip).Take(take).ToList();
            return list;
        }

        public async Task<bool> AddAsync(AdminPanelCreateOrEditViewModel vm)
        {
            try
            {
                var email = StringFixer.Fixer(vm.Email);
                var username = StringFixer.Fixer(vm.UserName);
                var pass = _security.HashPassword(vm.Password);
                User adduser = new User();
                adduser.CreateDate = DateTime.Now;
                adduser.Email = email;
                adduser.Password = pass;
                adduser.UserName = username;
                adduser.EmailActiveCode = GeneratorGuid.GeneratorUniqCode();
                adduser.IsBlocked = false;
                adduser.IsEmailActive = true;
                adduser.LastModifyDate = DateTime.Now;

                #region image

                if (vm.AvatarFile != null)
                {
                    var imagepath = "";
                    adduser.AvatarImageName = "pic" + GeneratorGuid.GeneratorUniqCode() + Path.GetExtension(vm.AvatarFile.FileName);
                    imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile",
                        adduser.AvatarImageName);
                    using (var stream = new FileStream(imagepath, FileMode.Create))
                    {
                        vm.AvatarFile.CopyTo(stream);
                    }

                }

                #endregion
                _context.Users.Add(adduser);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

            }

            return true;

        }

        public async Task<bool> EditAsync(AdminPanelCreateOrEditViewModel vm)
        {
            User user = await _context.Users.FindAsync(vm.Id);
            user.UserName = vm.UserName;
            if (!string.IsNullOrWhiteSpace(vm.Password))
            {
                user.Password = _security.HashPassword(vm.Password);
            }
            else
            {
                user.Password = user.Password;
            }

            var useremail = await _context.Users.SingleOrDefaultAsync(u => u.Email == vm.Email);
            if (useremail == null)
            {
                if (!string.IsNullOrWhiteSpace(vm.Email))
                {
                    user.Email = StringFixer.Fixer(vm.Email);
                }
                else
                {
                    user.Email = user.Email;
                }
            }

            user.LastModifyDate = DateTime.Now;
            #region UpdateImage
            //First need to remove current image
            if (vm.AvatarFile != null)
            {
                var DeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile",
                    user.AvatarImageName);
                if (File.Exists(DeletePath))
                {
                    File.Delete(DeletePath);
                }

                user.AvatarImageName = "pic" + GeneratorGuid.GeneratorUniqCode() + Path.GetExtension(vm.AvatarFile.FileName);
                var imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Profile",
                    user.AvatarImageName);
                using (var stream = new FileStream(imagepath, FileMode.Create))
                {
                    vm.AvatarFile.CopyTo(stream);
                }
            }
            #endregion

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);
            user.IsDeleted = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IPagedList<AdminPanelIndexViewModel>> GetAllToShowAsync(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {
            if (pageId <= 0) pageId = 1;
            IEnumerable<AdminPanelIndexViewModel> result;
            result = _context.Users.ConvertorAdminPanelIndexViewModel();

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));
            }

            if (!string.IsNullOrEmpty(FilterUserName))
            {
                result = result.Where(u => u.UserName.Contains(FilterUserName));
            }

            return result
                .OrderByDescending(u => u.CreateDate)
                .ToPagedList(pageId, Values.PageSize);
        }

        public async Task<List<AdminPanelIndexViewModel>> ShowDetail()
        {
            return await _context.Users.ConvertorAdminPanelIndexViewModel().ToListAsync();
        }

        public async Task<bool> IsUsernameDuplicated(string username)
        {
            var userName = StringFixer.Fixer(username);
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> IsEmailDuplicated(string emial)
        {
            var mail = StringFixer.Fixer(emial);
            return await _context.Users.AnyAsync(u => u.Email == mail);
        }

        public async Task<AdminPanelCreateOrEditViewModel> ShowUserForEditAsync(int id) =>
            _context.Users.Where(u => u.Id == id).Select(u => new AdminPanelCreateOrEditViewModel()
            {
                Email = u.Email,
                CreateDate = u.CreateDate,
                AvatarImageName = u.AvatarImageName,
                UserName = u.UserName,
                PermissionList = u.UserRoles.Select(r => r.RoleId).ToList()
            }).Single();

        public async Task<int> getUserId(AdminPanelCreateOrEditViewModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == model.UserName);
            return user.Id;
        }

        public Task<List<AdminPanelIndexViewModel>> GetAllAsync()
        {
            IQueryable<AdminPanelIndexViewModel> result = _context.Users.ConvertorAdminPanelIndexViewModel();
            return result.ToListAsync();
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
