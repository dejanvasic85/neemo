using System;

namespace Neemo.Web.Models
{
    public class ProviderSummaryView
    {
        public int ProviderId { get; set; }
        public string Title { get; set; }
        public string ImageId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Address { get; set; }
    }
}