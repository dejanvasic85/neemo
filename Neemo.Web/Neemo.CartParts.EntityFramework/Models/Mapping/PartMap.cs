using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class PartMap : EntityTypeConfiguration<Part>
    {
        public PartMap()
        {
            // Primary Key
            this.HasKey(t => t.PartID);

            // Properties
            this.Property(t => t.Part1)
                .HasMaxLength(100);

            this.Property(t => t.PartNo)
                .HasMaxLength(100);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.ThumbNailPath)
                .HasMaxLength(100);

            this.Property(t => t.ProductpecPath)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            this.Property(t => t.ShortDescription)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Part");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Part1).HasColumnName("Part");
            this.Property(t => t.PartNo).HasColumnName("PartNo");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.ThumbNailPath).HasColumnName("ThumbNailPath");
            this.Property(t => t.ProductpecPath).HasColumnName("ProductpecPath");
            this.Property(t => t.DefaultPartPhotoID).HasColumnName("DefaultPartPhotoID");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUser).HasColumnName("CreatedByUser");
            this.Property(t => t.LastModifiedDateTime).HasColumnName("LastModifiedDateTime");
            this.Property(t => t.LastModifiedByUser).HasColumnName("LastModifiedByUser");
            this.Property(t => t.DeletedDateTime).HasColumnName("DeletedDateTime");
            this.Property(t => t.DeletedByUser).HasColumnName("DeletedByUser");
            this.Property(t => t.EffectiveDateFrom).HasColumnName("EffectiveDateFrom");
            this.Property(t => t.EffectiveDateTo).HasColumnName("EffectiveDateTo");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasOptional(t => t.PartPhoto)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.DefaultPartPhotoID);

        }
    }
}
