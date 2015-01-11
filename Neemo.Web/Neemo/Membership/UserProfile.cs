namespace Neemo.Membership
{

    public class UserProfile
    {
        // RegistrationTable -> EmailAddress
        public string Email { get; set; }

        public PersonalDetails BillingDetails { get; set; }
        public PersonalDetails ShippingDetails { get; set; }

        public bool TermsAccepted { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string OriginIP { get; set; }
        public bool AdminUser { get; set; }
        public bool Active { get; set; } // Always true
        public bool IsSubscribedToNewsletter { get; set; }
    }
}
