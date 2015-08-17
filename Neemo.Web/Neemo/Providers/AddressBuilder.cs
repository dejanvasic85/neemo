using System.Text;

namespace Neemo.Providers
{
    public class AddressBuilder
    {
        public string UnitNo { get; private set; }
        public string StreetNumber { get; private set; }
        public string StreetName { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }

        public AddressBuilder WithUnit(string unitNo)
        {
            this.UnitNo = unitNo;
            return this;
        }

        public AddressBuilder WithStreet(string streetNumber, string streetName)
        {
            this.StreetNumber = streetNumber;
            this.StreetName = streetName;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            this.State = state;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            this.City = city;
            return this;
        }

        public AddressBuilder WithPostCode(string postcode)
        {
            this.PostCode = postcode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            this.Country = country;
            return this;
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            AppendToAddress(builder, UnitNo, "Unit " + UnitNo);
            AppendToAddress(builder, StreetName, StreetNumber + " " + StreetName);
            AppendToAddress(builder, City);
            AppendToAddress(builder, State);
            AppendToAddress(builder, PostCode);
            AppendToAddress(builder, Country);

            return builder.ToString();
        }
        
        private void AppendToAddress(StringBuilder builder, string value, string formatted = "")
        {
            if (value.IsNullOrEmpty())
            {
                return;
            }

            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            // Always take the formatted string (if any) over the value
            builder.Append(formatted.IsNullOrEmpty() ? value : formatted);
        }
    }
}