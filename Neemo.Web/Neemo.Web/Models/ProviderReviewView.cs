using System;

namespace Neemo.Web.Models
{
    public class ProviderReviewView
    {
        public int ProviderId { get; set; }
        public decimal Score { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ReviewerName { get; set; }
    }
}