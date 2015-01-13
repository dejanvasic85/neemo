using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Vw_PartDetails_All
    {
        public string Part { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Category { get; set; }
        public string PartNo { get; set; }
        public int PartID { get; set; }
        public Nullable<int> DefaultPartPhotoID { get; set; }
        public int PartPhotoID { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string PhotoName { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Weight { get; set; }
    }
}
