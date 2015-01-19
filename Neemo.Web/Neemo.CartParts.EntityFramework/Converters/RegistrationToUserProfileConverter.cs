using AutoMapper;
using Neemo.CarParts.EntityFramework.Models;
using Neemo.Membership;

namespace Neemo.CarParts.EntityFramework
{
    public class RegistrationToUserProfileConverter : TypeConverter<Models.Registration, UserProfile>
    {
        protected override UserProfile ConvertCore(Registration source)
        {
            var billingDetails = new PersonalDetails
            {
                AddressLine1 = source.Address,
                City = source.City,
                Company = source.CompanyName,
                Country = source.CountryCode,
                FirstName = source.FirstName,
                IsDefault = true,
                PhoneNumber = source.Mobile,
                Postcode = source.PostCode.ToString(),
                State = source.State,
                Surname = source.LastName
            };

            var shippingDetails = new PersonalDetails
            {
                AddressLine1 = source.Shipping_Address,
                City = source.Shipping_City,
                Company = source.Shipping_CompanyName,
                Country = source.Shipping_CountryID,
                FirstName = source.Shipping_FirstName,
                IsDefault = true,
                PhoneNumber = source.Shipping_Mobile,
                Postcode = source.Shipping_PostCode.ToString(),
                State = source.Shipping_State,
                Surname = source.Shipping_LastName
            };

            UserProfile profile = UserProfile.Create(
                source.UserName,
                source.UserPassword,
                source.EmailAddress,
                source.IsSubscribedToNewsletter.GetValueOrDefault(),
                source.OriginIP,
                billingDetails, 
                shippingDetails
                );

            return profile;
        }
    }
}