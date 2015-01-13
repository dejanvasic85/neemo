using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Region
    {
        public Region()
        {
            this.Suburbs = new List<Suburb>();
        }

        public int RegionID { get; set; }
        public string Region1 { get; set; }
        public string RegionShort { get; set; }
        public Nullable<int> StateID { get; set; }
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
        public virtual State State { get; set; }
        public virtual ICollection<Suburb> Suburbs { get; set; }
    }
}
