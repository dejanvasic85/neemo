using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class BodyType
    {
        public BodyType()
        {
            this.Wrecks = new List<Wreck>();
        }

        public int BodyTypeID { get; set; }
        public string BodyType1 { get; set; }
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
        public virtual ICollection<Wreck> Wrecks { get; set; }
    }
}
