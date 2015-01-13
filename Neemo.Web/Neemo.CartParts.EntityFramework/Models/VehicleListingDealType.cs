using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class VehicleListingDealType
    {
        public int VehicleListingDealTypeID { get; set; }
        public Nullable<int> VehicleListingID { get; set; }
        public Nullable<int> DealTypeID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual DealType DealType { get; set; }
        public virtual VehicleListing VehicleListing { get; set; }
    }
}
