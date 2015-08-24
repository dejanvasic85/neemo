using System;
using System.Collections.Generic;
using Neemo.CustomerReviews;

namespace Neemo.Providers
{
    public class Provider
    {
        public Provider()
        {
            AvailableServices = new List<ProviderServiceType>();
            CustomerReviews = new List<CustomerReview>();
        }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LevelNo { get; set; }
        public string UnitNo { get; set; }
        public string StreetNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PostCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string URL { get; set; }
        public decimal? Rating { get; set; }
        public string ContactUsURL { get; set; }
        public int? DisplayOrderId { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedByUser { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string DeletedByUser { get; set; }
        public DateTime? EffectiveDateFrom { get; set; }
        public DateTime? EffectiveDateTo { get; set; }
        public List<ProviderServiceType> AvailableServices { get; set; }
        public List<CustomerReview> CustomerReviews { get; set; }

    
        public string ToDisplayAddress()
        {
            AddressBuilder builder = new AddressBuilder();

            builder.WithUnit(UnitNo)
                .WithStreet(StreetNo, Street)
                .WithCity(City)
                .WithState(State)
                .WithPostCode(PostCode.ToString())
                ;

            return builder.ToString();
        }
    }
}