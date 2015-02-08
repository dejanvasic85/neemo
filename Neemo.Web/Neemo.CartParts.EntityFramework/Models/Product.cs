using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int WreckID { get; set; }
        public int PartID { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Comment { get; set; }
        public decimal CostPrice { get; set; }
        public bool Active { get; set; }
        public Nullable<bool> onSpecial { get; set; }
        public bool Soldout { get; set; }
        public Nullable<int> Discount { get; set; }
        public string SpecialsNote { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<bool> DisplayonHomePage { get; set; }
        public Nullable<bool> Featured { get; set; }
        public Nullable<bool> New { get; set; }
        public Nullable<bool> TopSeller { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Part Part { get; set; }
        public virtual Wreck Wreck { get; set; }
        public virtual ICollection<ProductPrice> ProducePrices { get; set; } 
    }
}
