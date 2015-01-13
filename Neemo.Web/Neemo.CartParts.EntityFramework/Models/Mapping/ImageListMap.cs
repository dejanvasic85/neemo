using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class ImageListMap : EntityTypeConfiguration<ImageList>
    {
        public ImageListMap()
        {
            // Primary Key
            this.HasKey(t => t.ImageListID);

            // Properties
            this.Property(t => t.ImageName)
                .HasMaxLength(200);

            this.Property(t => t.ThumbNailImageName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ImageList");
            this.Property(t => t.ImageListID).HasColumnName("ImageListID");
            this.Property(t => t.ImageName).HasColumnName("ImageName");
            this.Property(t => t.ThumbNailImageName).HasColumnName("ThumbNailImageName");
            this.Property(t => t.CreatedDatetime).HasColumnName("CreatedDatetime");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.ListingHeaderID).HasColumnName("ListingHeaderID");
        }
    }
}
