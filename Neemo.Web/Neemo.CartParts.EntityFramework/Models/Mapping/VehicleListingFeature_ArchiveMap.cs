using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class VehicleListingFeature_ArchiveMap : EntityTypeConfiguration<VehicleListingFeature_Archive>
    {
        public VehicleListingFeature_ArchiveMap()
        {
            // Primary Key
            this.HasKey(t => t.VehicleListingFeature_ArchiveID);

            // Properties
            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleListingFeature_Archive");
            this.Property(t => t.VehicleListingFeature_ArchiveID).HasColumnName("VehicleListingFeature_ArchiveID");
            this.Property(t => t.VehicleListingFeatureID).HasColumnName("VehicleListingFeatureID");
            this.Property(t => t.VehicleListingID).HasColumnName("VehicleListingID");
            this.Property(t => t.FeatureID).HasColumnName("FeatureID");
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
            this.HasOptional(t => t.Feature)
                .WithMany(t => t.VehicleListingFeature_Archive)
                .HasForeignKey(d => d.FeatureID);
            this.HasOptional(t => t.VehicleListing)
                .WithMany(t => t.VehicleListingFeature_Archive)
                .HasForeignKey(d => d.VehicleListingID);

        }
    }
}
