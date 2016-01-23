using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HsrOrderApp.BL.DomainModel
{
    public class SupplierCondition
    {
        public SupplierCondition()
        {
            this.SupplierId = default(int);
            this.ProductId = default(int);
        }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }
    }
}
