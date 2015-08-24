using System;
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class ProviderDetailView
    {
        public ProviderDetailView()
        {
            AvailableServices = new List<string>();
        }
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
        public List<string> AvailableServices { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public int ReviewCount { get; set; }
        public string CurrentUsername { get; set; }
    }
}