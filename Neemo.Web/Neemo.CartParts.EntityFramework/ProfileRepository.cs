using Neemo.Membership;

namespace Neemo.CarParts.EntityFramework
{
    public class ProfileRepository : IProfileRepository
    {
        public UserProfile GetProfile(string email)
        {
            return new UserProfile
            {
                BillingDetails = MockPersonalDetails(),
                ShippingDetails = MockPersonalDetails()
            };
        }

        private PersonalDetails MockPersonalDetails()
        {
            return new PersonalDetails
            {
                FirstName = "Johnny",
                Surname = "Chase",
                IsDefault = true,
                AddressLine1 = "1 Melbourne Street",
                City = "Melbourne CBD",
                Postcode = "3000",
                PhoneNumber = "04333000333",
                State = "VIC"
            };
        }
    }
}