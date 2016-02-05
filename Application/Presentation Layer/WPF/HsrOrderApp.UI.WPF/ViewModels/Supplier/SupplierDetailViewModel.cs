using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using HsrOrderApp.UI.WPF.ViewModels.Product;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierDetailViewModel : DetailViewModelBase<SupplierDTO>
    {
        private ProductViewModel productViewModel;

        public SupplierDetailViewModel(SupplierDTO supplier, bool isNew)
            : base(supplier, isNew)
        {
            this.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
        }

        public ProductViewModel ProductViewModel
        {
            get
            {
                if (this.productViewModel == null && this.IsNew == false)
                {
                    this.productViewModel = new ProductViewModel(this.Model);
                    this.productViewModel.LoadCommand.Command.Execute(null);
                }
                return this.productViewModel;
            }
        }

        protected override void SaveData()
        {
            this.Service.StoreSupplier(this.Model);
            this.SaveCommandExecuted();
        }
    }
}