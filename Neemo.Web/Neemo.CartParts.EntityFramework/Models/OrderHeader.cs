using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class OrderHeader
    {
        public OrderHeader()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int OrderHeaderID { get; set; }
        public int? RegistrationID { get; set; }
        public string RecordSourceIP { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> TaxTotal { get; set; }
        public Nullable<decimal> ShippingCharges { get; set; }
        public Nullable<decimal> Handlingcharges { get; set; }
        public Nullable<int> OrderStatusID { get; set; }
        public string Billing_LastName { get; set; }
        public string Billing_FirstName { get; set; }
        public string Billing_CompanyName { get; set; }
        public string Billing_Address { get; set; }
        public string Billing_City { get; set; }
        public string Billing_State { get; set; }
        public string Billing_PostCode { get; set; }
        public string Billing_Country { get; set; }
        public string Billing_Email { get; set; }
        public string Billing_Phone { get; set; }
        public string Billing_Mobile { get; set; }
        public string Billing_Fax { get; set; }
        public string Shipping_FirstName { get; set; }
        public string Shipping_LastName { get; set; }
        public string Shipping_CompanyName { get; set; }
        public string Shipping_Address { get; set; }
        public string Shipping_City { get; set; }
        public string Shipping_State { get; set; }
        public string Shipping_PostCode { get; set; }
        public string Shipping_Country { get; set; }
        public string Shipping_Email { get; set; }
        public string Shipping_Phone { get; set; }
        public string Shipping_Mobile { get; set; }
        public string Shipping_Fax { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
        public string GUID { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PaymentTransactionId { get; set; }
        public string InvoiceNumber { get; set; }
    }
}
