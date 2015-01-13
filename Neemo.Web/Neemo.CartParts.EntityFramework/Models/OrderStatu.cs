using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class OrderStatu
    {
        public OrderStatu()
        {
            this.OrderHeaders = new List<OrderHeader>();
        }

        public int OrderStatusID { get; set; }
        public string OrderStatus { get; set; }
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
