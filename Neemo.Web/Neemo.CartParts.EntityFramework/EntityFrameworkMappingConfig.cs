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

            MapOrder(config);

            MapOrderItems(config);
        }

        private static void MapRegistration(IConfiguration config)
        {
            // To database
            config.CreateMap<Neemo.Membership.UserProfile, Models.Registration>().ConvertUsing<UserProfileToRegistrationConverter>();


            // From Database
            config.CreateMap<Models.Registration, Membership.UserProfile>().ConvertUsing<RegistrationToUserProfileConverter>();
        }

        private static void MapProduct(IConfiguration config)
        {
            // To database ( ignore everything except the fields that we are updating )
            config.CreateMap<Store.Product, Models.Product>()
                .ForMember(m => m.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(m => m.Qty, options => options.MapFrom(src => src.AvailableQty))

                .ForMember(m => m.New, options => options.Ignore())
                .ForMember(m => m.Featured, options => options.Ignore())
                .ForMember(m => m.TopSeller, options => options.Ignore())
                .ForMember(m => m.Active, options => options.Ignore())
                .ForMember(m => m.Comment, options => options.Ignore())
                .ForMember(m => m.CostPrice, options => options.Ignore())
                .ForMember(m => m.CreatedDateTime, options => options.Ignore())
                .ForMember(m => m.Discount, options => options.Ignore())
                .ForMember(m => m.DisplayonHomePage, options => options.Ignore())
                .ForMember(m => m.Part, options => options.Ignore())
                .ForMember(m => m.ProducePrices, options => options.Ignore())
                .ForMember(m => m.Soldout, options => options.Ignore())
                .ForMember(m => m.SpecialsNote, options => options.Ignore())
                .ForMember(m => m.Wreck, options => options.Ignore())
                .ForMember(m => m.WreckID, options => options.Ignore())
                .ForMember(m => m.onSpecial, options => options.Ignore())
                ;

            // From Database
            config.CreateMap<Models.Product, Neemo.Store.Product>()
                .ForMember(m => m.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(m => m.IsNew, options => options.MapFrom(src => src.New))
                .ForMember(m => m.IsFeatured, options => options.MapFrom(src => src.Featured))
                .ForMember(m => m.IsBestSeller, options => options.MapFrom(src => src.TopSeller))
                .ForMember(m => m.AvailableQty, options => options.MapFrom(src => src.Qty))
                .ForMember(m => m.ProductSpecifications, options => options.Ignore())
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

        private static void MapOrder(IConfiguration config)
        {
            // To Database
            config.CreateMap<Orders.Order, Models.OrderHeader>()
                .ForMember(m => m.Active, options => options.UseValue(true))
                .ForMember(m => m.Billing_Address, options => options.MapFrom(src => src.BillingDetails.AddressLine1))
                .ForMember(m => m.Billing_City, options => options.MapFrom(src => src.BillingDetails.City))
                .ForMember(m => m.Billing_CompanyName, options => options.MapFrom(src => src.BillingDetails.Company))
                .ForMember(m => m.Billing_Country, options => options.MapFrom(src => src.BillingDetails.Country))
                .ForMember(m => m.Billing_Email, options => options.Ignore())
                .ForMember(m => m.Billing_Fax, options => options.Ignore())
                .ForMember(m => m.Billing_FirstName, options => options.MapFrom(src => src.BillingDetails.FirstName))
                .ForMember(m => m.Billing_LastName, options => options.MapFrom(src => src.BillingDetails.Surname))
                .ForMember(m => m.Billing_Mobile, options => options.MapFrom(src => src.BillingDetails.PhoneNumber))
                .ForMember(m => m.Billing_Phone, options => options.MapFrom(src => src.BillingDetails.PhoneNumber))
                .ForMember(m => m.Billing_PostCode, options => options.MapFrom(src => src.BillingDetails.Postcode))
                .ForMember(m => m.Billing_State, options => options.MapFrom(src => src.BillingDetails.State))

                .ForMember(m => m.Shipping_Address, options => options.MapFrom(src => src.ShippingDetails.AddressLine1))
                .ForMember(m => m.Shipping_City, options => options.MapFrom(src => src.ShippingDetails.City))
                .ForMember(m => m.Shipping_CompanyName, options => options.MapFrom(src => src.ShippingDetails.Company))
                .ForMember(m => m.Shipping_Country, options => options.MapFrom(src => src.ShippingDetails.Country))
                .ForMember(m => m.Shipping_Email, options => options.Ignore())
                .ForMember(m => m.Shipping_Fax, options => options.Ignore())
                .ForMember(m => m.Shipping_FirstName, options => options.MapFrom(src => src.ShippingDetails.FirstName))
                .ForMember(m => m.Shipping_LastName, options => options.MapFrom(src => src.ShippingDetails.Surname))
                .ForMember(m => m.Shipping_Mobile, options => options.MapFrom(src => src.ShippingDetails.PhoneNumber))
                .ForMember(m => m.Shipping_Phone, options => options.MapFrom(src => src.ShippingDetails.PhoneNumber))
                .ForMember(m => m.Shipping_PostCode, options => options.MapFrom(src => src.ShippingDetails.Postcode))
                .ForMember(m => m.Shipping_State, options => options.MapFrom(src => src.ShippingDetails.State))
                .ForMember(m => m.ShippingCharges, options => options.MapFrom(src => src.ShippingTotal))

                .ForMember(m => m.DateCreated, options => options.MapFrom(src => src.CreatedDateTime))
                .ForMember(m => m.DateDeleted, options => options.Ignore())
                .ForMember(m => m.GUID, options => options.MapFrom(src => src.GUID))
                .ForMember(m => m.Handlingcharges, options => options.Ignore())
                .ForMember(m => m.OrderHeaderID, options => options.MapFrom(src => src.OrderId))
                .ForMember(m => m.OrderStatu, options => options.Ignore())
                .ForMember(m => m.RecordSourceIP, options => options.MapFrom(src => src.SourceIpAddress))
                .ForMember(m => m.RegistrationID, options => options.Ignore())
                .ForMember(m => m.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(m => m.OrderDetails, options => options.MapFrom(src => src.OrderLineItems))
                ;

            // From Database
            config.CreateMap<Models.OrderHeader, Orders.Order>()
                .ConvertUsing<OrderHeaderToOrderConverter>()
                ;
        }

        private static void MapOrderItems(IConfiguration config)
        {
            // To Database
            config.CreateMap<Orders.OrderLineItem, Models.OrderDetail>()
                .ForMember(m => m.OrderDetailID, options => options.MapFrom(src => src.OrderLineItemId))
                .ForMember(m => m.OrderHeader, options => options.Ignore())
                .ForMember(m => m.DateCreated, options => options.MapFrom(src => src.CreatedDateTime))
                .ForMember(m => m.DateDeleted, options => options.Ignore())
                .ForMember(m => m.OrderHeaderID, options => options.MapFrom(src => src.OrderId))
                .ForMember(m => m.Product, options => options.Ignore())
                .ForMember(m => m.ProductID, options => options.MapFrom(src => src.ProductId))
                .ForMember(m => m.Quantity, options => options.MapFrom(src => src.Quantity))
                .ForMember(m => m.TaxTotal, options => options.MapFrom(src => src.TaxTotal))
                .ForMember(m => m.TotalValue, options => options.MapFrom(src => src.TotalValue))
                .ForMember(m => m.UnitPrice, options => options.MapFrom(src => src.UnitPrice))
                .ForMember(m => m.Active, options => options.UseValue(true)) // Default to true
                ;

            // From Database
            config.CreateMap<Models.OrderDetail, Orders.OrderLineItem>()
                .ForMember(m => m.OrderId, options => options.MapFrom(src => src.OrderHeaderID))
                .ForMember(m => m.OrderLineItemId, options => options.MapFrom(src => src.OrderDetailID))
                .ForMember(m=> m.CreatedDateTime, options => options.MapFrom(src => src.DateCreated))
                .ForMember(m=> m.ProductId, options => options.MapFrom(src => src.ProductID))
                .ForMember(m=> m.Quantity, options => options.MapFrom(src => src.Quantity))
                .ForMember(m=> m.TaxTotal, options => options.MapFrom(src => src.TaxTotal))
                .ForMember(m=> m.TotalValue, options => options.MapFrom(src => src.TotalValue))
                .ForMember(m=> m.UnitPrice, options => options.MapFrom(src => src.UnitPrice))
                ;
        }

    }
}
