using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.ViewModel.PermiossionSelfViewModel;
using CodeTo.Core.ViewModel.PermiossionViewModel;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Core.Services.PermiossionServices
{
    public class PermiossionService : IPermiossionService
    {
        private readonly CodeToContext _context;

        public PermiossionService(CodeToContext context)
        {
            _context = context;
        }

        public async Task<PermissionCreateorEditeViewModel> Find(byte id)
        {
            throw new NotImplementedException();
        }

        //TODO Add Permission to permission db
        public async Task<bool> AddAsync(PermissionCreateorEditeViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditAsync(PermissionCreateorEditeViewModel vm)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.RoleID == vm.Id);
            if (!string.IsNullOrEmpty(vm.Title))
            {
                role.RoleTitle = vm.Title;
            }

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(byte id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.RoleID == id);
            role.IsDeleted = true;
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PermissionIndexViewModel>> GetAll()
        {
            var roles = _context.Roles;
            return await roles.permissionToVM().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddPermissionToUserAsync(List<byte> roleId, int userid)
        {
            foreach (var roleid in roleId)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleid,
                    UserId = userid
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditPermissionToUserAsync(List<byte> roleId, int userid)
        {
            //first We need to remove actual roles
            _context.UserRoles.Where(r => r.UserId == userid).ToList().ForEach(r => _context.UserRoles.Remove(r));
            await AddPermissionToUserAsync(roleId, userid);
            return true;
        }

        public async Task<bool> DuplicateRoleAsync(string title)
        {
            return await _context.Roles.AnyAsync(r => r.RoleTitle == title);
        }

        public async Task<byte> AddRoleAsync(PermissionCreateorEditeViewModel model)
        {
            Role role = new Role();
            role.CreatDate = DateTime.Now;
            role.RoleTitle = model.Title;
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.RoleID;
        }

        public PermissionCreateorEditeViewModel ShowPermission(byte id)
        {
            return _context.Roles.Where(r => r.RoleID == id).Select(r => new PermissionCreateorEditeViewModel()
            {
                CreateDate = r.CreatDate,
                Title = r.RoleTitle
            }).Single();
        }

        public List<PermiossionViewModel> GetAllPermissionAsync()
        {
            return _context.Permissions.Select(p => new PermiossionViewModel()
            {
                Title = p.Title,
                PermissionId = p.PermissionId,
                ParentId = p.ParentId
            }
            ).ToList();
        }
    }

}
