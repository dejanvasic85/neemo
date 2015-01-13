using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class SuburbMap : EntityTypeConfiguration<Suburb>
    {
        public SuburbMap()
        {
            // Primary Key
            this.HasKey(t => t.SuburbID);

            // Properties
            this.Property(t => t.Suburb1)
                .HasMaxLength(100);

            this.Property(t => t.PostCode)
                .HasMaxLength(50);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Suburb");
            this.Property(t => t.SuburbID).HasColumnName("SuburbID");
            this.Property(t => t.Suburb1).HasColumnName("Suburb");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
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
            this.HasRequired(t => t.Region)
                .WithMany(t => t.Suburbs)
                .HasForeignKey(d => d.RegionID);

        }
    }
}
