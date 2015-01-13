using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Feature
    {
        public Feature()
        {
            this.PartFeatures = new List<PartFeature>();
            this.VehicleListingFeature_Archive = new List<VehicleListingFeature_Archive>();
            this.VehicleListingFeatures = new List<VehicleListingFeature>();
        }

        public int FeatureID { get; set; }
        public string Feature1 { get; set; }
        public string Image { get; set; }
        public Nullable<bool> StandardFeature { get; set; }
        public Nullable<bool> AfterMarketFeature { get; set; }
        public Nullable<bool> Approved { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual ICollection<PartFeature> PartFeatures { get; set; }
        public virtual ICollection<VehicleListingFeature_Archive> VehicleListingFeature_Archive { get; set; }
        public virtual ICollection<VehicleListingFeature> VehicleListingFeatures { get; set; }
    }
}
