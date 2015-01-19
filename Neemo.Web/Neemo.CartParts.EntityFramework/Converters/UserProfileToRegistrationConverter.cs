using AutoMapper;
using Neemo.CarParts.EntityFramework.Models;
using Neemo.Membership;

namespace Neemo.CarParts.EntityFramework
{
    public class UserProfileToRegistrationConverter : TypeConverter<UserProfile, Models.Registration>
    {
        protected override Registration ConvertCore(UserProfile src)
        {
            var registration = new Registration();

            if (src.BillingDetails != null)
            {
                registration.Address = src.BillingDetails.AddressLine1;
                registration.City = src.BillingDetails.City;
                registration.CompanyName = src.BillingDetails.Company;
                registration.CountryCode = src.BillingDetails.Country;
                registration.FirstName = src.BillingDetails.FirstName;
                registration.LastName = src.BillingDetails.Surname;
                registration.Mobile = src.BillingDetails.PhoneNumber;
                registration.Phone = src.BillingDetails.PhoneNumber;
                registration.PostCode = int.Parse(src.BillingDetails.Postcode);
            }

            if (src.ShippingDetails != null)
            {
                registration.Shipping_Address = src.ShippingDetails.AddressLine1;
                registration.Shipping_City = src.ShippingDetails.City;
                registration.Shipping_CompanyName = src.ShippingDetails.Company;
                registration.Shipping_CountryID = src.ShippingDetails.Country;
                registration.Shipping_FirstName = src.ShippingDetails.FirstName;
                registration.Shipping_LastName = src.ShippingDetails.Surname;
                registration.Shipping_Mobile = src.ShippingDetails.PhoneNumber;
                registration.Shipping_Phone = src.ShippingDetails.PhoneNumber;
                registration.Shipping_PostCode = int.Parse(src.ShippingDetails.Postcode);
                registration.Shipping_State = src.ShippingDetails.State;
            }

            registration.Active = true;
            registration.AdminUser = false;
            registration.CarDealerShip = false;
            registration.CreatedByUser = src.UserName;
            registration.EmailAddress = src.Email;
            registration.IsSubscribedToNewsletter = src.IsSubscribedToNewsletter;
            registration.LastModifiedByUser = src.UserName;
            registration.UserPassword = src.UserPassword;
            registration.TermsAccepted = true;
            registration.OriginIP = src.RegistrationIpAddress;
            registration.Shipping_EmailAddress = src.Email;

            return registration;
        }
    }
}