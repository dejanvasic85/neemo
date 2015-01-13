using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.IsoCode);

            // Properties
            this.Property(t => t.IsoCode)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Country");
            this.Property(t => t.IsoCode).HasColumnName("IsoCode");
            this.Property(t => t.Title).HasColumnName("Title");
        }
    }
}
