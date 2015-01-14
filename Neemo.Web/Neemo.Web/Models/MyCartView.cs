using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neemo.Web.Models
{
    public class MyCartView
    {
        public PersonalDetailsView ShippingDetails { get; set; }
     
        [Required]
        public string ShippingType { get; set; }

        public List<ShippingCostView> ShippingOptions { get; set; }
    }
}