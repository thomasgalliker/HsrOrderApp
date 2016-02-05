using HsrOrderApp.SharedLibraries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HsrOrderApp.UI.Mvc.Models
{
    public class SupplierListViewModel : ListViewModelBase<SupplierListDTO>
    {
        public SupplierListViewModel() { }
        public SupplierListViewModel(List<SupplierListDTO> list) { Items = list; }
        public string prodId { get; set; }
    }

    public class SupplierViewModel : DetailViewModelBase<SupplierListDTO>
    {
        public SupplierViewModel() { }
        public SupplierViewModel(SupplierListDTO model, bool isNew) : base(model, isNew) { }
        public string prevProdId { get; set; }
    }
}