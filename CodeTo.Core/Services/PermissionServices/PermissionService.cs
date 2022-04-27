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
    public class PermissionService : IPermissionService
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
                    RoleTitle = vm.RoleName
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
            var model = await _context.Roles.FirstOrDefaultAsync(c => c.Id == id);
            return model.ToRolePermissionAddEditViewModel();
        }

        public async Task<bool> UpdateRole(RolePermissionAddOrEditViewModel vm)
        {
            try
            {
                var model = new Role()
                {
                    RoleTitle = vm.RoleName
                };
                RemoveRolePermissions(vm.RoleId);
                _context.Roles.Update(model);

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

        public async Task<List<PermissionsViewModel>> GetAllPermission()
        {
            return _context.RolePermissions.Select(p => p.ToPermissionsViewModel()).ToList();
        }
        public IQueryable<RolePermissionAddOrEditViewModel> GetAllRole()
        {
            return _context.Roles
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.User)
                .Select(c => c.ToRolePermissionAddEditViewModel());
        }
        public List<UserRoleViewModel> GetAllUserRole()
        {
            return _context.UserRoles.Select(p => new UserRoleViewModel()
            {
                UserId = p.UserId,
                UserRoleId = p.UR,
                RoleId = p.RoleId

            }).ToList();
        }

        public async Task<bool> AddUserRoleAsync(UserRoleViewModel vm)
        {
            var model = new UserRole()
            {
                UR = vm.UserRoleId,
                UserId = vm.UserId,
                RoleId = vm.RoleId
            };
            await _context.UserRoles.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUserRole(UserRoleViewModel vm)
        {
            try
            {
                var model = new UserRole()
                {
                    UR = vm.UserRoleId,
                    UserId = vm.UserId,
                    RoleId = vm.RoleId
                };
                _context.UserRoles.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("خطای افزودن نقش جدید" + e.Message);
                return false;
            }
        }

        public bool ExistsUserRole(int id)
        {
            return _context.UserRoles.Any(c => c.UR == id);
        }

        public async Task<UserRoleViewModel> FindUserRoleAsync(int ur)
        {
            var model = await _context.UserRoles
                .FirstOrDefaultAsync(c => c.UR == ur);
            return model.ToUserRoleViewModel();
        }
        public async Task<bool> DeleteUserRoleAsync(int id)
        {
            UserRole user = await _context.UserRoles.FindAsync(id);
            user.IsDeleted = true;
            _context.UserRoles.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PermissionsViewModel>> GetPermissionByRoleId(int roleid)
        {
            return await _context.RolePermissions
                .Where(r => r.RoleId == roleid)
                .Select(p => p.ToPermissionsViewModel()).ToListAsync();
        }
    }
}
