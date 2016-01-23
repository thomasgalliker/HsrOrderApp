using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierListDTO : DTOBase
    {
        public SupplierListDTO()
        {
        }

        [DataMember]
        public string Name { get; set; }
    }
}