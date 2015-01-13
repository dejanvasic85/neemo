using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class CylinderMap : EntityTypeConfiguration<Cylinder>
    {
        public CylinderMap()
        {
            // Primary Key
            this.HasKey(t => t.CylinderID);

            // Properties
            this.Property(t => t.Cylinder1)
                .HasMaxLength(100);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cylinder");
            this.Property(t => t.CylinderID).HasColumnName("CylinderID");
            this.Property(t => t.Cylinder1).HasColumnName("Cylinder");
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
        }
    }
}
