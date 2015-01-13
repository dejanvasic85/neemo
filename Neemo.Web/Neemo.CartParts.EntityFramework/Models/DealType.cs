using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class DealType
    {
        public DealType()
        {
            this.VehicleListingDealType_Archive = new List<VehicleListingDealType_Archive>();
            this.VehicleListingDealTypes = new List<VehicleListingDealType>();
        }

        public int DealTypeID { get; set; }
        public string DealType1 { get; set; }
        public string Image { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual ICollection<VehicleListingDealType_Archive> VehicleListingDealType_Archive { get; set; }
        public virtual ICollection<VehicleListingDealType> VehicleListingDealTypes { get; set; }
    }
}
