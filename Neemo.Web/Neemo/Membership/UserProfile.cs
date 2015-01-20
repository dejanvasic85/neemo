namespace Neemo.Membership
{

    public class UserProfile
    {
        public static UserProfile Create(string username, string password, string email, bool newsletterSubscription, string registrationIpAddress,
            PersonalDetails billingDetails = null, PersonalDetails shippingDetails = null)
        {
            return new UserProfile
            {
                UserName = username,
                UserPassword = password,
                Email = email,
                RegistrationIpAddress = registrationIpAddress,
                IsSubscribedToNewsletter = newsletterSubscription,

                // Initialise these but they will provide them later
                BillingDetails = billingDetails,
                ShippingDetails = shippingDetails
            };
        }


        public string Email { get; private set; }
        public PersonalDetails BillingDetails { get; private set; }
        public PersonalDetails ShippingDetails { get; private set; }
        public string UserName { get; private set; }
        public string UserPassword { get; private set; }
        public bool IsSubscribedToNewsletter { get; private set; }
        public string RegistrationIpAddress { get; private set; }

        public void UpdateShipping(PersonalDetails shippingDetails)
        {
            this.ShippingDetails = shippingDetails;
        }
    }
}
