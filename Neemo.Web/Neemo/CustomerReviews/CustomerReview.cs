using System;

namespace Neemo.CustomerReviews
{
    public class CustomerReview
    {
        public int? CustomerReviewId { get; set; }
        public decimal Score { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public DateTime? EffectiveDateFrom { get; set; }
        public DateTime? EffectiveDateTo { get; set; }
    }
}
