#region

using System.Runtime.Serialization;
using HsrOrderApp.SharedLibraries.DTO.Requests_Responses.Base;
using HsrOrderApp.SharedLibraries.SharedEnums;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO.Requests_Responses
{
    public class GetSuppliersRequest : RequestType
    {
        public int ProductId { get; set; }
    }
}