using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    public class CreateSupplierWithLinkToProductRequest : RequestType
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string SupplierName { get; set; }
    }
}
