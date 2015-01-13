using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class PartFeatureMap : EntityTypeConfiguration<PartFeature>
    {
        public PartFeatureMap()
        {
            // Primary Key
            this.HasKey(t => t.PartFeatureID);

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
            this.ToTable("PartFeature");
            this.Property(t => t.PartFeatureID).HasColumnName("PartFeatureID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.FeatureID).HasColumnName("FeatureID");
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
            this.HasOptional(t => t.Feature)
                .WithMany(t => t.PartFeatures)
                .HasForeignKey(d => d.FeatureID);
            this.HasRequired(t => t.Part)
                .WithMany(t => t.PartFeatures)
                .HasForeignKey(d => d.PartID);

        }
    }
}
