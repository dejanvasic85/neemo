using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neemo.Web.Models
{
    public class ProductSummary
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageId { get; set; }
    }
}