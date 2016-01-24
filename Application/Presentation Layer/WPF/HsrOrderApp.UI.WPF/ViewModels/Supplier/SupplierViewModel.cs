using System.Collections.Generic;
using System.Linq;

using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.PresentationLogic;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using HsrOrderApp.UI.WPF.ViewModels.Security;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierViewModel : ListViewModelBase<SupplierListDTO>
    {
        protected override void LoadData()
        {
            this.DisplayName = Strings.UserViewModel_DisplayName;
            IList<SupplierListDTO> users = this.Service.GetAllSuppliers();
            foreach (var user in users)
            {
                this.Items.Add(user);
            }
        }

        protected override void New()
        {
            var newSupplier = new SupplierDTO();
            var detailModelView = new SupplierDetailViewModel(newSupplier, true);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                this.Load();
                this.SelectedItem = this.Items.SingleOrDefault(dto => dto.Id == newSupplier.Id);
            }
        }

        protected override void Delete()
        {
            this.Service.DeleteSupplier(this.SelectedItem.Id);
            this.Load();
        }

        protected override void Edit()
        {
            var selectedDto = this.Service.GetSupplierById(this.SelectedItem.Id);
            var detailModelView = new SupplierDetailViewModel(selectedDto, false);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                this.Load();
                this.SelectedItem = this.Items.SingleOrDefault(dto => dto.Id == selectedDto.Id);
            }
        }
    }
}