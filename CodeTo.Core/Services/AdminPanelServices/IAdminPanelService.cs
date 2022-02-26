using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Core.Interfase;
using CodeTo.Core.ViewModel.AdminPanel;

namespace CodeTo.Core.Services.AdminPanelServices
{
   public interface IAdminPanelService : IGenericInterface<int, AdminPanelIndexViewModel, AdminPanelCreateOrEditViewModel>
    {

        public Task<AdminPanelIndexViewModel> GetAllToShowAsync(int pageId = 1, string FilterEmail = "",
            string FilterUserName = "");

        public Task<List<AdminPanelIndexViewModel>> ShowDetail();
        Task<bool> IsUsernameDuplicated(string username);
        Task<bool> IsEmailDuplicated(string emial);
        Task<AdminPanelCreateOrEditViewModel> ShowUserForEditAsync(int id);
        Task<int> getUserId(AdminPanelCreateOrEditViewModel model);
        Task<int> SecondAddAsync(AdminPanelCreateOrEditViewModel vm);

        Task<AdminPanelIndexViewModel> GetAllDeletedToShowAsync(int pageId = 1, string FilterEmail = "",
            string FilterUserName = "");
    }
}
