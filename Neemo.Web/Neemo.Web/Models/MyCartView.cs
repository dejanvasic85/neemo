using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class MyCartView
    {
        public PersonalDetailsView ShippingDetails { get; set; }
     
        public string ShippingType { get; set; }

        public List<ShippingCostView> ShippingOptions { get; set; }
    }
}