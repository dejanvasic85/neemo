using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Part
    {
        public Part()
        {
            this.PartFeatures = new List<PartFeature>();
            this.PartPhotoes = new List<PartPhoto>();
            this.Products = new List<Product>();
        }

        public int PartID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Part1 { get; set; }
        public string PartNo { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string Image { get; set; }
        public string ThumbNailPath { get; set; }
        public string ProductpecPath { get; set; }
        public Nullable<int> DefaultPartPhotoID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual PartPhoto PartPhoto { get; set; }
        public virtual ICollection<PartFeature> PartFeatures { get; set; }
        public virtual ICollection<PartPhoto> PartPhotoes { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
