﻿using System.Collections.Generic;

namespace Neemo.Store
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string QuickOverview { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public string ImageId { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestSeller { get; set; }
        public int AvailableQty { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; } 
        public decimal Price { get; set; }

        public bool IsOutOfStock()
        {
            if (!IsAvailable)
                return true;

            return IsAvailable && AvailableQty == 0;
        }

        // Todo - WreckTable - Get all foreign keys to display the Part/Wreck specific shite!
        
        public dynamic Features { get; set; }
        
        public void ReduceQuantity(int quantity)
        {
            this.AvailableQty = this.AvailableQty - quantity;
        }
    }
}