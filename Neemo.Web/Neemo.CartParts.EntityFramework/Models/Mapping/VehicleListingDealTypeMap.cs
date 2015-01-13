using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class VehicleListingDealTypeMap : EntityTypeConfiguration<VehicleListingDealType>
    {
        public VehicleListingDealTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.VehicleListingDealTypeID);

            // Properties
            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleListingDealType");
            this.Property(t => t.VehicleListingDealTypeID).HasColumnName("VehicleListingDealTypeID");
            this.Property(t => t.VehicleListingID).HasColumnName("VehicleListingID");
            this.Property(t => t.DealTypeID).HasColumnName("DealTypeID");
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
            this.HasOptional(t => t.DealType)
                .WithMany(t => t.VehicleListingDealTypes)
                .HasForeignKey(d => d.DealTypeID);
            this.HasOptional(t => t.VehicleListing)
                .WithMany(t => t.VehicleListingDealTypes)
                .HasForeignKey(d => d.VehicleListingID);

        }
    }
}
