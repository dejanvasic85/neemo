using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class ImageList
    {
        public int ImageListID { get; set; }
        public string ImageName { get; set; }
        public string ThumbNailImageName { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> ListingHeaderID { get; set; }
    }
}
