using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class VehicleListingApproval
    {
        public int VehicleListingApprovalID { get; set; }
        public Nullable<int> VehicleListingID { get; set; }
        public Nullable<bool> Approved { get; set; }
        public Nullable<bool> Rejected { get; set; }
        public Nullable<System.DateTime> DateApproved { get; set; }
        public Nullable<System.DateTime> DateRejected { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual VehicleListing VehicleListing { get; set; }
    }
}
