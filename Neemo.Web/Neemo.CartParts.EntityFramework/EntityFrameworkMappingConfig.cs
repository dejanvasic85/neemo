using System;
using System.Linq;
using AutoMapper;

namespace Neemo.CarParts.EntityFramework
{
    public class EntityFrameworkMappingConfig : IMappingConfig
    {
        public void RegisterMapping<TMapper>(TMapper mapper)
        {
            if (typeof(TMapper) != typeof(AutoMapper.IConfiguration))
            {
                throw new ArgumentException("TMapper must be of type AutoMapper.Mapper");
            }


            var config = (IConfiguration)mapper;


            MapCategory(config);

            MapProduct(config);

            MapRegistration(config);
        }

        private static void MapRegistration(IConfiguration config)
        {
            // To database
            config.CreateMap<Neemo.Membership.UserProfile, Models.Registration>()
                .ForMember(m => m.Active, options => options.UseValue(true))
                .ForMember(m => m.Address, options => options.MapFrom(src => src.BillingDetails.AddressLine1))
                .ForMember(m => m.AdminUser, options => options.UseValue(false))
                .ForMember(m => m.CarDealerShip, options => options.UseValue(false))
                .ForMember(m => m.City, options => options.MapFrom(src => src.BillingDetails.City))
                .ForMember(m => m.CompanyName, options => options.MapFrom(src => src.BillingDetails.Company))
                .ForMember(m => m.CountryCode, options => options.MapFrom(src => src.BillingDetails.Country))
                .ForMember(m => m.CreatedByUser, options => options.MapFrom(src => src.UserName))
                .ForMember(m => m.EmailAddress, options => options.MapFrom(src => src.Email))
                .ForMember(m => m.FirstName, options => options.MapFrom(src => src.BillingDetails.FirstName))
                .ForMember(m => m.Image, options => options.Ignore())
                .ForMember(m => m.Fax, options => options.Ignore())
                .ForMember(m => m.IsSubscribedToNewsletter, options => options.MapFrom(src => src.IsSubscribedToNewsletter))
                .ForMember(m => m.LastModifiedByUser, options => options.MapFrom(src => src.UserName))
                .ForMember(m => m.UserPassword, options => options.MapFrom(src => src.UserPassword))
                .ForMember(m => m.TermsAccepted, options => options.UseValue(true))
                .ForMember(m => m.LastName, options => options.MapFrom(src => src.BillingDetails.Surname))
                .ForMember(m => m.Mobile, options => options.MapFrom(src => src.BillingDetails.PhoneNumber))
                .ForMember(m => m.Phone, options => options.MapFrom(src => src.BillingDetails.PhoneNumber))
                .ForMember(m => m.PostCode, options => options.MapFrom(src => src.BillingDetails.Postcode))
                .ForMember(m => m.OriginIP, options => options.MapFrom(src => src.RegistrationIpAddress))
                .ForMember(m => m.Shipping_Address, options => options.MapFrom(src => src.ShippingDetails.AddressLine1))
                .ForMember(m => m.Shipping_City, options => options.MapFrom(src => src.ShippingDetails.City))
                .ForMember(m => m.Shipping_CompanyName, options => options.MapFrom(src => src.ShippingDetails.Company))
                .ForMember(m => m.Shipping_CountryID, options => options.MapFrom(src => src.ShippingDetails.Country))
                .ForMember(m => m.Shipping_EmailAddress, options => options.MapFrom(src => src.Email))
                .ForMember(m => m.Shipping_Fax, options => options.Ignore())
                .ForMember(m => m.Shipping_FirstName, options => options.MapFrom(src=> src.ShippingDetails.FirstName))
                .ForMember(m => m.Shipping_LastName, options => options.MapFrom(src=> src.ShippingDetails.Surname))
                .ForMember(m => m.Shipping_Mobile, options => options.MapFrom(src=> src.ShippingDetails.PhoneNumber))
                .ForMember(m => m.Shipping_Phone, options => options.MapFrom(src=> src.ShippingDetails.PhoneNumber))
                .ForMember(m => m.Shipping_PostCode, options => options.MapFrom(src=> src.ShippingDetails.Postcode))
                .ForMember(m => m.Shipping_State, options => options.MapFrom(src=> src.ShippingDetails.State))
                ;



            // From Database
            config.CreateMap<Models.Registration, Membership.UserProfile>()
                .ForMember(m => m.Email, options=> options.MapFrom(src => src.EmailAddress))
                .ForMember(m => m.UserName, options=> options.MapFrom(src => src.UserName))
                .ForMember(m => m.IsSubscribedToNewsletter, options=> options.MapFrom(src => src.IsSubscribedToNewsletter))
                .ForMember(m => m.RegistrationIpAddress, options=> options.MapFrom(src => src.OriginIP))
                .ForMember(m => m.ShippingDetails, options=> options.Ignore())
                .ForMember(m => m.BillingDetails, options=> options.Ignore())
                .ForMember(m => m.UserPassword, options=> options.Ignore())
                ;
        }

        private static void MapProduct(IConfiguration config)
        {
            config.CreateMap<Models.Product, Neemo.Store.Product>()
                .ForMember(m => m.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(m => m.IsNew, options => options.MapFrom(src => src.New))
                .ForMember(m => m.Features, options => options.MapFrom(src => src.Featured))
                .ForMember(m => m.IsBestSeller, options => options.MapFrom(src => src.TopSeller))
                .ForMember(m => m.AvailableQty, options => options.MapFrom(src => src.Qty))
                .ForMember(m => m.Features, options => options.Ignore())
                .ForMember(m => m.IsAvailable, options => options.MapFrom(s => !s.Soldout))
                .ForMember(m => m.Price, options => options.MapFrom(src => src.ProducePrices.First().Price))
                .ForMember(m => m.Title, options => options.MapFrom(src => src.Part.Part1))
                .ForMember(m => m.QuickOverview, options => options.MapFrom(src => src.Part.ShortDescription))
                .ForMember(m => m.Description, options => options.MapFrom(src => src.Part.Description))
                .ForMember(m => m.Images,
                    options => options.MapFrom(src => src.Part.PartPhotoes.Select(p => p.PhotoName).ToArray()))
                .ForMember(m => m.ImageId, options => options.MapFrom(src => src.Part.PartPhoto.PhotoName))
                .ForMember(m => m.CategoryId, options => options.MapFrom(src => src.Part.CategoryID))
                ;
        }

        private static void MapCategory(IConfiguration config)
        {
            config.CreateMap<Models.Category, Neemo.Store.Category>()
                .ForMember(m => m.ParentId, options => options.Ignore())
                .ForMember(m => m.CategoryId, options => options.MapFrom(src => src.CategoryID))
                .ForMember(m => m.Title, options => options.MapFrom(src => src.Category1))
                ;
        }
    }
}
