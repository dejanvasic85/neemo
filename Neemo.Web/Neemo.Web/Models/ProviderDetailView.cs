using System;
using System.Linq;

namespace Neemo.Web.Models
{
    public class ProviderDetailView
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string URL { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public decimal? Rating { get; set; }

    }
}