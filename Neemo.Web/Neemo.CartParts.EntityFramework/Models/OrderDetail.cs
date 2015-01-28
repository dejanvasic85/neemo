using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Nullable<int> OrderHeaderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public Nullable<decimal> TaxTotal { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public virtual Product Product { get; set; }
        public virtual string ProductName { get; set; }
    }
}
