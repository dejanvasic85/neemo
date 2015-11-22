using System;

namespace Neemo.Web.Models
{
    public class ProviderReviewView
    {
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }
        public decimal Score { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
    }
}