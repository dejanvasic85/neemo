using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neemo.Web.Models
{
    public class MyCartView
    {
        public List<CountryView> ShippingCountries { get; set; }
        public PersonalDetailsView ShippingDetails { get; set; }
     
        [Required]
        public string ShippingType { get; set; }
    }
}