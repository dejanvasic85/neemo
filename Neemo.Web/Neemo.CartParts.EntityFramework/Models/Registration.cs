using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Registration
    {
        public Registration()
        {
            this.OrderHeaders = new List<OrderHeader>();
        }

        public int RegistrationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> PostCode { get; set; }
        public string CountryCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<bool> TermsAccepted { get; set; }
        public Nullable<bool> CarDealerShip { get; set; }
        public Nullable<bool> PrivateProfile { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Nullable<int> UserLevel { get; set; }
        public string OriginIP { get; set; }
        public string URL { get; set; }
        public string Shipping_FirstName { get; set; }
        public string Shipping_LastName { get; set; }
        public string Shipping_CompanyName { get; set; }
        public string Shipping_Address { get; set; }
        public string Shipping_City { get; set; }
        public string Shipping_State { get; set; }
        public Nullable<int> Shipping_PostCode { get; set; }
        public string Shipping_CountryID { get; set; }
        public string Shipping_Mobile { get; set; }
        public string Shipping_Phone { get; set; }
        public string Shipping_Fax { get; set; }
        public string Shipping_EmailAddress { get; set; }
        public Nullable<bool> AdminUser { get; set; }
        public string Image { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public Nullable<System.DateTime> LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public Nullable<System.DateTime> DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public Nullable<System.DateTime> EffectiveDateFrom { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public Nullable<bool> IsSubscribedToNewsletter { get; set; }
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
        public virtual Registration Registration1 { get; set; }
        public virtual Registration Registration2 { get; set; }
    }
}
