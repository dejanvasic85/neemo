using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class TestimonialMap : EntityTypeConfiguration<Testimonial>
    {
        public TestimonialMap()
        {
            // Primary Key
            this.HasKey(t => t.TestimonialID);

            // Properties
            this.Property(t => t.Testimonial1)
                .IsRequired();

            this.Property(t => t.FullName)
                .HasMaxLength(100);

            this.Property(t => t.Suburb)
                .HasMaxLength(100);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Testimonial");
            this.Property(t => t.TestimonialID).HasColumnName("TestimonialID");
            this.Property(t => t.Testimonial1).HasColumnName("Testimonial");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Suburb).HasColumnName("Suburb");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Approved).HasColumnName("Approved");
        }
    }
}
