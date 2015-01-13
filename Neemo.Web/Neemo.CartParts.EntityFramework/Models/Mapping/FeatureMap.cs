using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class FeatureMap : EntityTypeConfiguration<Feature>
    {
        public FeatureMap()
        {
            // Primary Key
            this.HasKey(t => t.FeatureID);

            // Properties
            this.Property(t => t.Feature1)
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
            this.ToTable("Feature");
            this.Property(t => t.FeatureID).HasColumnName("FeatureID");
            this.Property(t => t.Feature1).HasColumnName("Feature");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.StandardFeature).HasColumnName("StandardFeature");
            this.Property(t => t.AfterMarketFeature).HasColumnName("AfterMarketFeature");
            this.Property(t => t.Approved).HasColumnName("Approved");
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
