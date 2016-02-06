using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    [DataContract]
    public class CreateSupplierWithLinkToProductResponse : ResponseType
    {
        [DataMember]
        public bool IsCreated { get; set; }
    }
}
