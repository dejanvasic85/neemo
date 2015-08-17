using System;

namespace Neemo.Web.Models
{
    public class ProviderSummaryView
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ImageId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Address { get; set; }
    }
}