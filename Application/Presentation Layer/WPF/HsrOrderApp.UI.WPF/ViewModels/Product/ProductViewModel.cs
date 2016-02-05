#region

using System.Collections.Generic;
using System.Linq;

using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.PresentationLogic;
using HsrOrderApp.UI.WPF.Properties;
using HsrOrderApp.UI.WPF.ViewModels.Base;

#endregion

namespace HsrOrderApp.UI.WPF.ViewModels.Product
{
    public class ProductViewModel : ListViewModelBase<ProductDTO>
    {
        private readonly SupplierDTO supplier;

        public ProductViewModel()
        {
        }

        public ProductViewModel(SupplierDTO supplier)
        {
            this.supplier = supplier;
        }

        protected override void LoadData()
        {
            this.DisplayName = Strings.ProductViewModel_DisplayName;

            IList<ProductDTO> products = null;
            if (this.supplier != null)
            {
                // TODO
                products = this.Service.GetProductsBySupplierId(this.supplier.Id);
            }
            else
            {
                products = this.Service.GetAllProducts();
            }

            foreach (ProductDTO product in products)
            {
                this.Items.Add(product);
            }
        }

        protected override void New()
        {
            ProductDTO newProduct = new ProductDTO();
            ProductDetailViewModel detailModelView = new ProductDetailViewModel(newProduct, true);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                this.Load();
                this.SelectedItem = this.Items.SingleOrDefault(dto => dto.Id == newProduct.Id);
            }
        }

        protected override void Delete()
        {
            this.Service.DeleteProduct(this.SelectedItem.Id);
            this.Load();
        }

        protected override void Edit()
        {
            ProductDTO selectedDto = this.Service.GetProductById(this.SelectedItem.Id);
            ProductDetailViewModel detailModelView = new ProductDetailViewModel(selectedDto, false);
            if (NavigationService.NavigateTo("Detail", detailModelView) == NavigationResult.Ok)
            {
                this.Load();
                this.SelectedItem = this.Items.SingleOrDefault(dto => dto.Id == selectedDto.Id);
            }
        }
    }
}