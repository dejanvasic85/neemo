namespace Neemo
{
    public class Country
    {
        public Country(string countryCode, string countryName)
        {
            this.IsoCountryCode = countryCode;
            this.Name = countryName;
        }

        public string IsoCountryCode { get; set; }
        public string Name { get; set; }
    }
}
