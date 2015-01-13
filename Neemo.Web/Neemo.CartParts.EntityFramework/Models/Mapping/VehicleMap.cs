using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            // Primary Key
            this.HasKey(t => t.VehicleID);

            // Properties
            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vehicle");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.MakeID).HasColumnName("MakeID");
            this.Property(t => t.ModelID).HasColumnName("ModelID");
            this.Property(t => t.BadgeID).HasColumnName("BadgeID");
            this.Property(t => t.SeriesID).HasColumnName("SeriesID");
            this.Property(t => t.Image).HasColumnName("Image");
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
            this.HasRequired(t => t.Badge)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.BadgeID);
            this.HasRequired(t => t.Make)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.MakeID);
            this.HasRequired(t => t.Model)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.ModelID);
            this.HasRequired(t => t.Series)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.SeriesID);

        }
    }
}
