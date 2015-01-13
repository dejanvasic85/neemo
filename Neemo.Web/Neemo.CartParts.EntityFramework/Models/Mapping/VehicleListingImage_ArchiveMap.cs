using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class VehicleListingImage_ArchiveMap : EntityTypeConfiguration<VehicleListingImage_Archive>
    {
        public VehicleListingImage_ArchiveMap()
        {
            // Primary Key
            this.HasKey(t => t.VehicleListingImage_ArchiveID);

            // Properties
            this.Property(t => t.VehicleListingImage_ArchiveD)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.VehicleListingImage_ArchiveID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Image)
                .HasMaxLength(200);

            this.Property(t => t.Image_ThumbNail)
                .HasMaxLength(200);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleListingImage_Archive");
            this.Property(t => t.VehicleListingImage_ArchiveD).HasColumnName("VehicleListingImage_ArchiveD");
            this.Property(t => t.VehicleListingImage_ArchiveID).HasColumnName("VehicleListingImage_ArchiveID");
            this.Property(t => t.VehicleListingID).HasColumnName("VehicleListingID");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Image_ThumbNail).HasColumnName("Image_ThumbNail");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUser).HasColumnName("CreatedByUser");
            this.Property(t => t.LastModifiedDateTime).HasColumnName("LastModifiedDateTime");
            this.Property(t => t.LastModifiedByUser).HasColumnName("LastModifiedByUser");
            this.Property(t => t.DeletedDateTime).HasColumnName("DeletedDateTime");
            this.Property(t => t.DeletedByUser).HasColumnName("DeletedByUser");
            this.Property(t => t.EffectiveDateFrom).HasColumnName("EffectiveDateFrom");
            this.Property(t => t.EffectiveDateTo).HasColumnName("EffectiveDateTo");

            // Relationships
            this.HasOptional(t => t.VehicleListing)
                .WithMany(t => t.VehicleListingImage_Archive)
                .HasForeignKey(d => d.VehicleListingID);

        }
    }
}
