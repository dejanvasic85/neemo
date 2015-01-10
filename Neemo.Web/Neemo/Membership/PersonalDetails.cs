namespace Neemo.Membership
{
    public class PersonalDetails
    {
        /// <summary>
        /// Indicates that these are the default details
        /// </summary>
        public bool IsDefault { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}