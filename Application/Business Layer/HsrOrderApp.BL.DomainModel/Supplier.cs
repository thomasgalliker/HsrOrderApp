using HsrOrderApp.BL.DomainModel.HelperObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.BL.DomainModel
{
    public class Supplier : DomainObject
    {
        public Supplier()
        {
            this.SupplierId = default(int);
            this.Name = string.Empty;
        }

        public int SupplierId { get; set; }

        public string Name { get; set; }
    }
}
