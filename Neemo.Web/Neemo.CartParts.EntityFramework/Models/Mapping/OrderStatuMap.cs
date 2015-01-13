using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class OrderStatuMap : EntityTypeConfiguration<OrderStatu>
    {
        public OrderStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderStatusID);

            // Properties
            this.Property(t => t.OrderStatus)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OrderStatus");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
        }
    }
}
