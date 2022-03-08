using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfaces;
using CodeTo.Core.Utilities.Other;
using CodeTo.Core.ViewModel.Permission;
using CodeTo.DataEF.Context;
using CodeTo.Domain.Entities.Permissions;
using CodeTo.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CodeTo.Core.Services.PermissionServices
{
   public class PermissionService:IPermissionService
    {
        private readonly CodeToContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoggerService<PermissionService> _logger;

        public PermissionService(CodeToContext context, ILoggerService<PermissionService> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _logger = logger;
            _currentUserService = currentUserService;
        }
        public IQueryable<ShowRoleViewModel> GetAllRoles()
        {
            return _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .Select(c => c.ToShowRoleViewModel());
        }

        public async Task<bool> AddRoleAsync(RolePermissionAddOrEditViewModel vm)
        {
            try
            {
                var model = new Role()
                {
                    RoleTitle = vm.Name
                };
                var role = await _context.Roles.AddAsync(model);
                await _context.SaveChangesAsync();

                foreach (var permissionName in vm.PermissionNames)
                {
                    await _context.RolePermissions.AddAsync(
                          new RolePermission()
                          {
                              RoleId = role.Entity.Id,
                              PermissionName = permissionName
                          });
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("خطای افزودن نقش جدید" + e.Message);
                return false;
            }
        }

        public async Task<RolePermissionAddOrEditViewModel> FindRoleAsync(int id)
        {
            var model = await _context.Roles.Include(c => c.RolePermissions).FirstOrDefaultAsync(c => c.Id == id);

            var vm = model.ToRolePermissionAddEditViewModel();
            vm.PermissionNames = _context.RolePermissions
                .Where(c => c.RoleId == id)
                .Select(c => c.PermissionName)
                .ToList();
            return vm;
        }

        public async Task<bool> UpdateRole(RolePermissionAddOrEditViewModel vm)
        {
            try
            {
                var model = new Role()
                {
                    RoleTitle = vm.Name
                };
                RemoveRolePermissions(vm.Id);
                _context.Roles.Update(model);
                foreach (var permissionName in vm.PermissionNames)
                {
                    await _context.RolePermissions.AddAsync(
                        new RolePermission()
                        {
                            RoleId = vm.Id,
                            PermissionName = permissionName
                        });
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("خطای افزودن نقش جدید" + e.Message);
                return false;
            }
        }

        public bool ExistsRole(int id)
        {
            return _context.Roles.Any(c => c.Id == id);
        }

        public async Task<bool> RemoveRoleAsync(int id)
        {
            try
            {
                if (!IsRemovable(id)) return false;
                var role = await _context.Roles.FindAsync(id);
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("خطای حذف نقش" + e.Message);
                return false;
            }
        }

        public void RemoveRolePermissions(int roleId)
        {
            var rolePermissions = _context.RolePermissions.Where(c => c.RoleId == roleId);
            _context.RolePermissions.RemoveRange(rolePermissions);
            _context.SaveChanges();
        }

        public async Task<bool> CheckPermission(string permissionName)
        {
            return await _context.UserRoles
                .Include(r => r.Role)
                .ThenInclude(r => r.RolePermissions)
                .AnyAsync(p =>
                p.UserId == _currentUserService.UserId &&
                p.Role.RolePermissions.Any(pe => pe.PermissionName == permissionName));
        }

        public bool IsSupperAdmin()
        {
            return _currentUserService.UserId == 1;
        }

        public async Task<IList<string>> GetCurrentUserPermissionsAsync()
        {
            return await _context.UserRoles.Where(c => c.UserId == _currentUserService.UserId)
                .Include(r => r.Role).ThenInclude(r => r.RolePermissions)
                .SelectMany(c => c.Role.RolePermissions).Select(c => c.PermissionName)
                .Distinct()
                .ToListAsync();
        }

        public bool IsRemovable(int roleId)
        {
            return !_context.UserRoles.Any(c => c.RoleId == roleId);
        }
    }
}
