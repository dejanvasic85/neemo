using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class PartPhoto
    {
        public PartPhoto()
        {
            this.Parts = new List<Part>();
        }

        public int PartPhotoID { get; set; }
        public int PartID { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoDetails { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual Part Part { get; set; }
    }
}
