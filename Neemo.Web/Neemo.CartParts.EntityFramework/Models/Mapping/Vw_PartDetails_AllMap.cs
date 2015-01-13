using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class Vw_PartDetails_AllMap : EntityTypeConfiguration<Vw_PartDetails_All>
    {
        public Vw_PartDetails_AllMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PartID, t.PartPhotoID, t.Quantity });

            // Properties
            this.Property(t => t.Part)
                .HasMaxLength(100);

            this.Property(t => t.Category)
                .HasMaxLength(100);

            this.Property(t => t.PartNo)
                .HasMaxLength(100);

            this.Property(t => t.PartID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PartPhotoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Quantity)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PhotoName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Vw_PartDetails_All");
            this.Property(t => t.Part).HasColumnName("Part");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.PartNo).HasColumnName("PartNo");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.DefaultPartPhotoID).HasColumnName("DefaultPartPhotoID");
            this.Property(t => t.PartPhotoID).HasColumnName("PartPhotoID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PhotoName).HasColumnName("PhotoName");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Weight).HasColumnName("Weight");
        }
    }
}
