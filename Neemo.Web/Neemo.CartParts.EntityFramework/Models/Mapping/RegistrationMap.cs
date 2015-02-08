using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class RegistrationMap : EntityTypeConfiguration<Registration>
    {
        public RegistrationMap()
        {
            // Primary Key
            this.HasKey(t => t.RegistrationID);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.CountryCode)
                .HasMaxLength(2);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.UserPassword)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.OriginIP)
                .HasMaxLength(50);

            this.Property(t => t.URL)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_LastName)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_CompanyName)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_Address)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_City)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_State)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_Phone)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_Fax)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_EmailAddress)
                .HasMaxLength(50);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Registration");
            this.Property(t => t.RegistrationID).HasColumnName("RegistrationID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
            this.Property(t => t.CountryCode).HasColumnName("CountryCode");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.TermsAccepted).HasColumnName("TermsAccepted");
            this.Property(t => t.CarDealerShip).HasColumnName("CarDealerShip");
            this.Property(t => t.PrivateProfile).HasColumnName("PrivateProfile");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.UserPassword).HasColumnName("UserPassword");
            this.Property(t => t.UserLevel).HasColumnName("UserLevel");
            this.Property(t => t.OriginIP).HasColumnName("OriginIP");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.Shipping_FirstName).HasColumnName("Shipping_FirstName");
            this.Property(t => t.Shipping_LastName).HasColumnName("Shipping_LastName");
            this.Property(t => t.Shipping_CompanyName).HasColumnName("Shipping_CompanyName");
            this.Property(t => t.Shipping_Address).HasColumnName("Shipping_Address");
            this.Property(t => t.Shipping_City).HasColumnName("Shipping_City");
            this.Property(t => t.Shipping_State).HasColumnName("Shipping_State");
            this.Property(t => t.Shipping_PostCode).HasColumnName("Shipping_PostCode");
            this.Property(t => t.Shipping_Mobile).HasColumnName("Shipping_Mobile");
            this.Property(t => t.Shipping_Phone).HasColumnName("Shipping_Phone");
            this.Property(t => t.Shipping_Fax).HasColumnName("Shipping_Fax");
            this.Property(t => t.Shipping_EmailAddress).HasColumnName("Shipping_EmailAddress");
            this.Property(t => t.AdminUser).HasColumnName("AdminUser");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUser).HasColumnName("CreatedByUser");
            this.Property(t => t.LastModifiedDateTime).HasColumnName("LastModifiedDateTime");
            this.Property(t => t.LastModifiedByUser).HasColumnName("LastModifiedByUser");
            this.Property(t => t.DeletedDateTime).HasColumnName("DeletedDateTime");
            this.Property(t => t.DeletedByUser).HasColumnName("DeletedByUser");
            this.Property(t => t.EffectiveDateFrom).HasColumnName("EffectiveDateFrom");
            this.Property(t => t.EffectiveDateTo).HasColumnName("EffectiveDateTo");
            this.Property(t => t.IsSubscribedToNewsletter).HasColumnName("IsSubscribedToNewsletter");

        }
    }
}
