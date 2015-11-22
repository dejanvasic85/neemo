using System;

namespace Neemo.Providers
{
    public class ProviderServiceType
    {
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
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