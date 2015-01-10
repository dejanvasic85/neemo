namespace Neemo.Membership
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PersonalDetails BillingDetails { get; set; }
        public PersonalDetails ShippingDetails { get; set; }
    }
}
