using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class PartPhotoMap : EntityTypeConfiguration<PartPhoto>
    {
        public PartPhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.PartPhotoID);

            // Properties
            this.Property(t => t.PhotoName)
                .HasMaxLength(100);

            this.Property(t => t.PhotoPath)
                .HasMaxLength(100);

            this.Property(t => t.PhotoDetails)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PartPhoto");
            this.Property(t => t.PartPhotoID).HasColumnName("PartPhotoID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.PhotoName).HasColumnName("PhotoName");
            this.Property(t => t.PhotoPath).HasColumnName("PhotoPath");
            this.Property(t => t.PhotoDetails).HasColumnName("PhotoDetails");
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
            this.HasRequired(t => t.Part)
                .WithMany(t => t.PartPhotoes)
                .HasForeignKey(d => d.PartID);

        }
    }
}
