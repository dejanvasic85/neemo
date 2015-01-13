using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Wreck
    {
        public Wreck()
        {
            this.Products = new List<Product>();
        }

        public int WreckID { get; set; }
        public string WreckNo { get; set; }
        public string KeyWord { get; set; }
        public Nullable<int> MakeID { get; set; }
        public Nullable<int> ModelID { get; set; }
        public Nullable<int> ChassisID { get; set; }
        public Nullable<int> EngineID { get; set; }
        public Nullable<int> EngineSizeID { get; set; }
        public Nullable<int> FuelTypeID { get; set; }
        public Nullable<int> BodyTypeID { get; set; }
        public Nullable<int> WheelBaseID { get; set; }
        public Nullable<int> YearID { get; set; }
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
        public virtual BodyType BodyType { get; set; }
        public virtual Chassis Chassis { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual EngineSize EngineSize { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Make Make { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual WheelBase WheelBase { get; set; }
        public virtual Year Year { get; set; }
    }
}
