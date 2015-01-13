using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.VehicleListings = new List<VehicleListing>();
        }

        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int BadgeID { get; set; }
        public int SeriesID { get; set; }
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
        public virtual Badge Badge { get; set; }
        public virtual Make Make { get; set; }
        public virtual Model Model { get; set; }
        public virtual Series Series { get; set; }
        public virtual ICollection<VehicleListing> VehicleListings { get; set; }
    }
}
