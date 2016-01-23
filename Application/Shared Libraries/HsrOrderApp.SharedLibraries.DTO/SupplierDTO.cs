#region

using System.Runtime.Serialization;

using HsrOrderApp.SharedLibraries.DTO.Base;

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

#endregion

namespace HsrOrderApp.SharedLibraries.DTO
{
    public class SupplierDTO : DTOParentObject
    {
        private string _name;

        public SupplierDTO()
        {
            this.Name = string.Empty;
        }

        [DataMember]
        [StringLengthValidator(1, 50)]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    this.OnPropertyChanged(() => this.Name);
                }
            }
        }
    }
}