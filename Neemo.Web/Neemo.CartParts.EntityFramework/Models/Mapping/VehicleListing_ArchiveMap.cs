using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class VehicleListing_ArchiveMap : EntityTypeConfiguration<VehicleListing_Archive>
    {
        public VehicleListing_ArchiveMap()
        {
            // Primary Key
            this.HasKey(t => t.VehicleListing_ArchiveID);

            // Properties
            this.Property(t => t.VehicleListing_ArchiveID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Heading)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.RegistrationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.DefaultImage)
                .HasMaxLength(200);

            this.Property(t => t.RegistrationPlateNumber)
                .HasMaxLength(50);

            this.Property(t => t.VINNumber)
                .HasMaxLength(50);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleListing_Archive");
            this.Property(t => t.VehicleListing_ArchiveID).HasColumnName("VehicleListing_ArchiveID");
            this.Property(t => t.VehicleListingID).HasColumnName("VehicleListingID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.Heading).HasColumnName("Heading");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.ConditionID).HasColumnName("ConditionID");
            this.Property(t => t.DealTypeID).HasColumnName("DealTypeID");
            this.Property(t => t.YearID).HasColumnName("YearID");
            this.Property(t => t.SuburbID).HasColumnName("SuburbID");
            this.Property(t => t.TransmissionID).HasColumnName("TransmissionID");
            this.Property(t => t.FuelTypeID).HasColumnName("FuelTypeID");
            this.Property(t => t.DriveTypeID).HasColumnName("DriveTypeID");
            this.Property(t => t.CylinderID).HasColumnName("CylinderID");
            this.Property(t => t.Kilometers).HasColumnName("Kilometers");
            this.Property(t => t.EngineSizeID).HasColumnName("EngineSizeID");
            this.Property(t => t.PowerID).HasColumnName("PowerID");
            this.Property(t => t.TowingID).HasColumnName("TowingID");
            this.Property(t => t.InductionID).HasColumnName("InductionID");
            this.Property(t => t.BodyTypeID).HasColumnName("BodyTypeID");
            this.Property(t => t.SeatID).HasColumnName("SeatID");
            this.Property(t => t.ColourID).HasColumnName("ColourID");
            this.Property(t => t.DoorID).HasColumnName("DoorID");
            this.Property(t => t.PPlateApproveID).HasColumnName("PPlateApproveID");
            this.Property(t => t.AncapRatingID).HasColumnName("AncapRatingID");
            this.Property(t => t.GreenRatingID).HasColumnName("GreenRatingID");
            this.Property(t => t.RegistrationID).HasColumnName("RegistrationID");
            this.Property(t => t.DefaultImage).HasColumnName("DefaultImage");
            this.Property(t => t.RoadWorthy).HasColumnName("RoadWorthy");
            this.Property(t => t.WrittenOff).HasColumnName("WrittenOff");
            this.Property(t => t.Registerd).HasColumnName("Registerd");
            this.Property(t => t.ShowPhoneNo).HasColumnName("ShowPhoneNo");
            this.Property(t => t.RegistrationPlateNumber).HasColumnName("RegistrationPlateNumber");
            this.Property(t => t.VINNumber).HasColumnName("VINNumber");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Approved).HasColumnName("Approved");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUser).HasColumnName("CreatedByUser");
            this.Property(t => t.LastModifiedDateTime).HasColumnName("LastModifiedDateTime");
            this.Property(t => t.LastModifiedByUser).HasColumnName("LastModifiedByUser");
            this.Property(t => t.DeletedDateTime).HasColumnName("DeletedDateTime");
            this.Property(t => t.DeletedByUser).HasColumnName("DeletedByUser");
            this.Property(t => t.EffectiveDateFrom).HasColumnName("EffectiveDateFrom");
            this.Property(t => t.EffectiveDateTo).HasColumnName("EffectiveDateTo");

            // Relationships
            this.HasRequired(t => t.AncapRating)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.AncapRatingID);
            this.HasRequired(t => t.AncapRating1)
                .WithMany(t => t.VehicleListing_Archive1)
                .HasForeignKey(d => d.AncapRatingID);
            this.HasRequired(t => t.BodyType)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.BodyTypeID);
            this.HasRequired(t => t.Colour)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.ColourID);
            this.HasRequired(t => t.Colour1)
                .WithMany(t => t.VehicleListing_Archive1)
                .HasForeignKey(d => d.ColourID);
            this.HasRequired(t => t.Condition)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.ConditionID);
            this.HasRequired(t => t.Cylinder)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.CylinderID);
            this.HasRequired(t => t.Door)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.DoorID);
            this.HasRequired(t => t.DriveType)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.DriveTypeID);
            this.HasRequired(t => t.EngineSize)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.EngineSizeID);
            this.HasRequired(t => t.FuelType)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.FuelTypeID);
            this.HasRequired(t => t.GreenRating)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.GreenRatingID);
            this.HasRequired(t => t.Induction)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.InductionID);
            this.HasRequired(t => t.Power)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.PowerID);
            this.HasRequired(t => t.PPlateApprove)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.PPlateApproveID);
            this.HasRequired(t => t.Seat)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.SeatID);
            this.HasRequired(t => t.Suburb)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.SuburbID);
            this.HasRequired(t => t.Towing)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.TowingID);
            this.HasRequired(t => t.Transmission)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.TransmissionID);
            this.HasRequired(t => t.VehicleListing)
                .WithOptional(t => t.VehicleListing_Archive);
            this.HasRequired(t => t.VehicleListing_Archive2)
                .WithOptional(t => t.VehicleListing_Archive1);
            this.HasRequired(t => t.Year)
                .WithMany(t => t.VehicleListing_Archive)
                .HasForeignKey(d => d.YearID);

        }
    }
}
