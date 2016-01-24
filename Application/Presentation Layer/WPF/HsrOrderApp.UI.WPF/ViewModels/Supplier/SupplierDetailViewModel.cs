using System.Collections.Generic;
using System.Linq;

using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;
using HsrOrderApp.UI.WPF.ViewModels.Security;

namespace HsrOrderApp.UI.WPF.ViewModels.Supplier
{
    public class SupplierDetailViewModel : DetailViewModelBase<SupplierDTO>
    {
        public SupplierDetailViewModel(SupplierDTO supplier, bool isNew)
            : base(supplier, isNew)
        {
            this.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
        }

        protected override void Load()
        {
            base.Load();
            //TODO GATH: Show Products of supplier here
            ////this.Customers = this.Service.GetAllCustomers().ToList();
            ////this.Customers.Insert(0, new CustomerListDTO { Id = default(int), Name = "<Kein Lieferant>" });
        }

        protected override void SaveData()
        {
            this.Service.StoreSupplier(this.Model);
            this.SaveCommandExecuted();
        }
    }
}