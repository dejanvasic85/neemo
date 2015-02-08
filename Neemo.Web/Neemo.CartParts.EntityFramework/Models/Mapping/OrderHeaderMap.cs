using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class OrderHeaderMap : EntityTypeConfiguration<OrderHeader>
    {
        public OrderHeaderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderHeaderID);

            // Properties
            this.Property(t => t.RecordSourceIP)
                .HasMaxLength(50);

            this.Property(t => t.Billing_LastName)
                .HasMaxLength(100);

            this.Property(t => t.Billing_FirstName)
                .HasMaxLength(100);

            this.Property(t => t.Billing_CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.Billing_Address)
                .HasMaxLength(100);

            this.Property(t => t.Billing_City)
                .HasMaxLength(50);

            this.Property(t => t.Billing_State)
                .HasMaxLength(50);

            this.Property(t => t.Billing_PostCode)
                .HasMaxLength(20);

            this.Property(t => t.Billing_Country)
                .HasMaxLength(50);

            this.Property(t => t.Billing_Email)
                .HasMaxLength(100);

            this.Property(t => t.Billing_Phone)
                .HasMaxLength(20);

            this.Property(t => t.Billing_Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Billing_Fax)
                .HasMaxLength(20);

            this.Property(t => t.Shipping_FirstName)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_LastName)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_Address)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_City)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_State)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_PostCode)
                .HasMaxLength(20);

            this.Property(t => t.Shipping_Country)
                .HasMaxLength(50);

            this.Property(t => t.Shipping_Email)
                .HasMaxLength(100);

            this.Property(t => t.Shipping_Phone)
                .HasMaxLength(20);

            this.Property(t => t.Shipping_Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Shipping_Fax)
                .HasMaxLength(20);

            this.Property(t => t.GUID)
                .HasMaxLength(100);

            this.Property(t => t.UserName)
                .HasMaxLength(100);

            this.Property(t => t.PaymentTransactionId)
                .HasMaxLength(100);

            this.Property(t => t.InvoiceNumber)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("OrderHeader");
            this.Property(t => t.OrderHeaderID).HasColumnName("OrderHeaderID");
            this.Property(t => t.RegistrationID).HasColumnName("RegistrationID");
            this.Property(t => t.RecordSourceIP).HasColumnName("RecordSourceIP");
            this.Property(t => t.TotalAmount).HasColumnName("TotalAmount");
            this.Property(t => t.TaxTotal).HasColumnName("TaxTotal");
            this.Property(t => t.ShippingCharges).HasColumnName("ShippingCharges");
            this.Property(t => t.Handlingcharges).HasColumnName("Handlingcharges");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.Billing_LastName).HasColumnName("Billing_LastName");
            this.Property(t => t.Billing_FirstName).HasColumnName("Billing_FirstName");
            this.Property(t => t.Billing_CompanyName).HasColumnName("Billing_CompanyName");
            this.Property(t => t.Billing_Address).HasColumnName("Billing_Address");
            this.Property(t => t.Billing_City).HasColumnName("Billing_City");
            this.Property(t => t.Billing_State).HasColumnName("Billing_State");
            this.Property(t => t.Billing_PostCode).HasColumnName("Billing_PostCode");
            this.Property(t => t.Billing_Country).HasColumnName("Billing_Country");
            this.Property(t => t.Billing_Email).HasColumnName("Billing_Email");
            this.Property(t => t.Billing_Phone).HasColumnName("Billing_Phone");
            this.Property(t => t.Billing_Mobile).HasColumnName("Billing_Mobile");
            this.Property(t => t.Billing_Fax).HasColumnName("Billing_Fax");
            this.Property(t => t.Shipping_FirstName).HasColumnName("Shipping_FirstName");
            this.Property(t => t.Shipping_LastName).HasColumnName("Shipping_LastName");
            this.Property(t => t.Shipping_CompanyName).HasColumnName("Shipping_CompanyName");
            this.Property(t => t.Shipping_Address).HasColumnName("Shipping_Address");
            this.Property(t => t.Shipping_City).HasColumnName("Shipping_City");
            this.Property(t => t.Shipping_State).HasColumnName("Shipping_State");
            this.Property(t => t.Shipping_PostCode).HasColumnName("Shipping_PostCode");
            this.Property(t => t.Shipping_Country).HasColumnName("Shipping_Country");
            this.Property(t => t.Shipping_Email).HasColumnName("Shipping_Email");
            this.Property(t => t.Shipping_Phone).HasColumnName("Shipping_Phone");
            this.Property(t => t.Shipping_Mobile).HasColumnName("Shipping_Mobile");
            this.Property(t => t.Shipping_Fax).HasColumnName("Shipping_Fax");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PaymentTransactionId).HasColumnName("PaymentTransactionId");
            this.Property(t => t.InvoiceNumber).HasColumnName("InvoiceNumber");

            // Relationships
            this.HasOptional(t => t.OrderStatu)
                .WithMany(t => t.OrderHeaders)
                .HasForeignKey(d => d.OrderStatusID);

        }
    }
}
