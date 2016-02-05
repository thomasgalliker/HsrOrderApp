using HsrOrderApp.SharedLibraries.DTO;
using HsrOrderApp.UI.Mvc.Controllers.Base;
using HsrOrderApp.UI.Mvc.Helpers;
using HsrOrderApp.UI.Mvc.Models;
using HsrOrderApp.UI.Mvc.Resources;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HsrOrderApp.UI.Mvc.Controllers
{
    [CustomAuthorize(RequiredPermissions = new UserPermission[] { UserPermission.ADMIN, UserPermission.STAFF })]
    public class SupplierController : HsrOrderAppController
    {
        // GET: Product
        public ActionResult Index()
        {
            var vm = new SupplierListViewModel();
            vm.DisplayName = Strings.ProductViewModel_DisplayName;
            vm.Items = Service.GetAllSuppliers().ToList();
            vm.SelectedItem = vm.Items.FirstOrDefault();

            // Finish Action
            return View(vm);
        }

        public ActionResult Details(string id)
        {
            var vm = new SupplierListViewModel();
            
            int prodId;
            if (int.TryParse(id, out prodId))
            {
                vm.Items = Service.GetSuppliersByProductId(prodId).ToList();
                vm.SelectedItem = vm.Items.FirstOrDefault();
                vm.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
                vm.prodId = id;

                // Finish Action
                return View(vm);
            }

            throw new HttpException(400, "There was an error with your request.");
        }

        public ActionResult Create(string prevProdId = "")
        {
            var vm = new SupplierViewModel();
            vm.DisplayName = Strings.SupplierDetailViewModel_DisplayName;
            vm.prevProdId = prevProdId;
            vm.Model = new SupplierListDTO();

            // Finish Action
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(SupplierViewModel vmChanged)
        {
            // TODO: Store Supplier
            //ProductViewModel vm = DisplayDetails(vmChanged);
            return null;
        }

    }
}
