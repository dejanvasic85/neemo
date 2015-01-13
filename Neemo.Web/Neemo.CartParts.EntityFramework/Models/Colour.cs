using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Colour
    {
        public Colour()
        {
            this.VehicleListing_Archive = new List<VehicleListing_Archive>();
            this.VehicleListing_Archive1 = new List<VehicleListing_Archive>();
            this.VehicleListings = new List<VehicleListing>();
            this.VehicleListings1 = new List<VehicleListing>();
        }

        public int ColourID { get; set; }
        public string Colour1 { get; set; }
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
        public virtual ICollection<VehicleListing_Archive> VehicleListing_Archive { get; set; }
        public virtual ICollection<VehicleListing_Archive> VehicleListing_Archive1 { get; set; }
        public virtual ICollection<VehicleListing> VehicleListings { get; set; }
        public virtual ICollection<VehicleListing> VehicleListings1 { get; set; }
    }
}
