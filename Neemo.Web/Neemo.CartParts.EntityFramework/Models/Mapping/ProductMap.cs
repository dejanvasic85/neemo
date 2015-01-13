using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.Soldout)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.WreckID).HasColumnName("WreckID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CostPrice).HasColumnName("CostPrice");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.onSpecial).HasColumnName("onSpecial");
            this.Property(t => t.Soldout).HasColumnName("Soldout");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.SpecialsNote).HasColumnName("SpecialsNote");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.DisplayonHomePage).HasColumnName("DisplayonHomePage");
            this.Property(t => t.Featured).HasColumnName("Featured");
            this.Property(t => t.New).HasColumnName("New");
            this.Property(t => t.TopSeller).HasColumnName("TopSeller");
            this.Property(t => t.BalanceQty).HasColumnName("BalanceQty");

            // Relationships
            this.HasRequired(t => t.Part)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.PartID);
            this.HasRequired(t => t.Wreck)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.WreckID);

        }
    }
}
