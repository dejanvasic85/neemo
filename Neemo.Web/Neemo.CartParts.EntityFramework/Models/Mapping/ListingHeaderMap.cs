using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class ListingHeaderMap : EntityTypeConfiguration<ListingHeader>
    {
        public ListingHeaderMap()
        {
            // Primary Key
            this.HasKey(t => t.ListingHeaderID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ListingHeader");
            this.Property(t => t.ListingHeaderID).HasColumnName("ListingHeaderID");
            this.Property(t => t.DefaultImageListID).HasColumnName("DefaultImageListID");
            this.Property(t => t.CreatedDatetime).HasColumnName("CreatedDatetime");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.TypeID).HasColumnName("TypeID");
            this.Property(t => t.ServiceID).HasColumnName("ServiceID");
            this.Property(t => t.FeatureID).HasColumnName("FeatureID");
            this.Property(t => t.ProjectID).HasColumnName("ProjectID");
        }
    }
}
