using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class ListingHeader
    {
        public int ListingHeaderID { get; set; }
        public Nullable<int> DefaultImageListID { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> FeatureID { get; set; }
        public Nullable<int> ProjectID { get; set; }
    }
}
