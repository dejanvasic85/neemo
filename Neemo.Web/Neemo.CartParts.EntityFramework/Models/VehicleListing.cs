using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class VehicleListing
    {
        public VehicleListing()
        {
            this.VehicleListingApprovals = new List<VehicleListingApproval>();
            this.VehicleListingDealType_Archive = new List<VehicleListingDealType_Archive>();
            this.VehicleListingDealTypes = new List<VehicleListingDealType>();
            this.VehicleListingFeature_Archive = new List<VehicleListingFeature_Archive>();
            this.VehicleListingFeatures = new List<VehicleListingFeature>();
            this.VehicleListingImage_Archive = new List<VehicleListingImage_Archive>();
            this.VehicleListingImages = new List<VehicleListingImage>();
        }

        public int VehicleListingID { get; set; }
        public int VehicleID { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ConditionID { get; set; }
        public int DealTypeID { get; set; }
        public int YearID { get; set; }
        public int SuburbID { get; set; }
        public int TransmissionID { get; set; }
        public int FuelTypeID { get; set; }
        public int DriveTypeID { get; set; }
        public int CylinderID { get; set; }
        public int Kilometers { get; set; }
        public int EngineSizeID { get; set; }
        public int PowerID { get; set; }
        public int TowingID { get; set; }
        public int InductionID { get; set; }
        public int BodyTypeID { get; set; }
        public int SeatID { get; set; }
        public int ColourID { get; set; }
        public int DoorID { get; set; }
        public int PPlateApproveID { get; set; }
        public int AncapRatingID { get; set; }
        public int GreenRatingID { get; set; }
        public int RegistrationID { get; set; }
        public string DefaultImage { get; set; }
        public Nullable<bool> RoadWorthy { get; set; }
        public Nullable<bool> WrittenOff { get; set; }
        public Nullable<int> Registerd { get; set; }
        public Nullable<bool> ShowPhoneNo { get; set; }
        public string RegistrationPlateNumber { get; set; }
        public string VINNumber { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public virtual AncapRating AncapRating { get; set; }
        public virtual AncapRating AncapRating1 { get; set; }
        public virtual BodyType BodyType { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual Colour Colour1 { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Cylinder Cylinder { get; set; }
        public virtual Door Door { get; set; }
        public virtual DriveType DriveType { get; set; }
        public virtual EngineSize EngineSize { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual GreenRating GreenRating { get; set; }
        public virtual Induction Induction { get; set; }
        public virtual Power Power { get; set; }
        public virtual PPlateApprove PPlateApprove { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Towing Towing { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual VehicleListing_Archive VehicleListing_Archive { get; set; }
        public virtual Year Year { get; set; }
        public virtual ICollection<VehicleListingApproval> VehicleListingApprovals { get; set; }
        public virtual ICollection<VehicleListingDealType_Archive> VehicleListingDealType_Archive { get; set; }
        public virtual ICollection<VehicleListingDealType> VehicleListingDealTypes { get; set; }
        public virtual ICollection<VehicleListingFeature_Archive> VehicleListingFeature_Archive { get; set; }
        public virtual ICollection<VehicleListingFeature> VehicleListingFeatures { get; set; }
        public virtual ICollection<VehicleListingImage_Archive> VehicleListingImage_Archive { get; set; }
        public virtual ICollection<VehicleListingImage> VehicleListingImages { get; set; }
    }
}
