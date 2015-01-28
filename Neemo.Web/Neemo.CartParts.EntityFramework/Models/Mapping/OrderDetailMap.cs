using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderDetailID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrderDetails");
            this.Property(t => t.OrderDetailID).HasColumnName("OrderDetailID");
            this.Property(t => t.OrderHeaderID).HasColumnName("OrderHeaderID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.TotalValue).HasColumnName("TotalValue");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.TaxTotal).HasColumnName("TaxTotal");
            this.Property(t => t.ProductName).HasColumnName("ProductName");

            // Relationships
            this.HasOptional(t => t.OrderHeader)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.OrderHeaderID);
            this.HasOptional(t => t.Product)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
