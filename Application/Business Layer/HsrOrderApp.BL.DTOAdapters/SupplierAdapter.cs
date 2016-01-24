using System.Collections.Generic;
using System.Linq;
using HsrOrderApp.BL.BusinessComponents;
using HsrOrderApp.BL.DomainModel;
using HsrOrderApp.BL.DTOAdapters.Helper;
using HsrOrderApp.SharedLibraries.DTO;

namespace HsrOrderApp.BL.DtoAdapters
{
    public static class SupplierAdapter
    {
        public static SupplierDTO SupplierToDTO(Supplier supplier)
        {
            var supplierDto = new SupplierDTO
            {
                Id = supplier.SupplierId,
                Name = supplier.Name,
                Version = supplier.Version,
            };

            return supplierDto;
        }

        public static IList<SupplierListDTO> SuppliersToDtos(IQueryable<Supplier> suppliers)
        {
            IQueryable<SupplierListDTO> dtos = from u in suppliers
                                               select SupplierToListDto(u);
            return dtos.ToList();
        }

        private static SupplierListDTO SupplierToListDto(Supplier supplier)
        {
            SupplierListDTO supplierListDto = new SupplierListDTO
            {
                Id = supplier.SupplierId,
                Name = supplier.Name,
            };

            return supplierListDto;
        }

        public static Supplier DtoToSupplier(SupplierDTO supplierDto)
        {
            var supplier = new Supplier
            {
                SupplierId = supplierDto.Id,
                Name = supplierDto.Name,
                Version = supplierDto.Version,
            };
            ValidationHelper.Validate(supplier);
            return supplier;
        }
    }
}