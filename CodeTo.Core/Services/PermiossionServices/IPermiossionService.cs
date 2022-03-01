using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;
using CodeTo.Core.ViewModel.PermiossionSelfViewModel;
using CodeTo.Core.ViewModel.PermiossionViewModel;

namespace CodeTo.Core.Services.PermiossionServices
{
   public interface IPermiossionService : IGenericService<byte, PermissionIndexViewModel, PermissionCreateorEditeViewModel>
    {
        Task<bool> AddPermissionToUserAsync(List<byte> roleId, int userid);
        Task<bool> EditPermissionToUserAsync(List<byte> roleId, int userid);
        Task<bool> DuplicateRoleAsync(string title);
        Task<byte> AddRoleAsync(PermissionCreateorEditeViewModel model);
        PermissionCreateorEditeViewModel ShowPermission(byte id);
        List<PermiossionViewModel> GetAllPermissionAsync();
    }
}
    

