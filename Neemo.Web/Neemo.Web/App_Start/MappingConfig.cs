using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Neemo.Web.Infrastructure;

namespace Neemo.Web
{
    public class MappingConfig : IMappingConfig
    {
        public void RegisterMapping<TMapper>(TMapper mapper)
        {
            if (typeof(TMapper) != typeof(AutoMapper.IConfiguration))
            {
                throw new ArgumentException("TMapper must be of type AutoMapper.Mapper");
            }

            var config = (AutoMapper.IConfiguration)mapper;

            // To view model
            config.CreateMap<Store.Product, Models.ProductSummaryView>()
                .ForMember(member => member.OutOfStock, options => options.ResolveUsing(t => t.IsOutOfStock()))
                .ForMember(member => member.TitleSlug, options => options.MapFrom(source => Slug.Create(source.Title, true)))
                ;

            config.CreateMap<Store.Product, Models.ProductDetailView>()
                .ForMember(member => member.ProductSpecifications, options => options.ResolveUsing<ProductSpecificationConverter>())
                .ForMember(member => member.OtherDetails, options => options.ResolveUsing<OtherDetailsConverter>());

            config.CreateMap<Store.ProductCartItem, Models.CartItemView>()
                .ForMember(member => member.ItemSubTotal, options => options.MapFrom(source => source.CalculateSubTotalWithoutTax()));

            config.CreateMap<Store.Category, Models.CategoryView>();
            config.CreateMap<Shipping.ShippingCost, Models.ShippingCostView>();
            config.CreateMap<Country, Models.CountryView>();
            config.CreateMap<PersonalDetails, Models.PersonalDetailsView>();
            config.CreateMap<Membership.UserProfile, Models.CheckoutView>();
            config.CreateMap<Tax.TaxCost, Models.TaxCostView>();
            config.CreateMap<ShoppingCart.Cart, Models.OrderSummaryView>().ConvertUsing<Models.CartToOrderSummaryConverter>();

            config.CreateMap<Orders.Order, Models.OrderView>();
            config.CreateMap<Orders.Order, Models.InvoiceDetailView>().ConvertUsing<Models.OrderToInvoiceConverter>();

            config.CreateMap<Orders.OrderLineItem, Models.OrderLineItemView>();
            config.CreateMap<Orders.OrderLineItem, Models.InvoiceItemView>().ConvertUsing<Models.OrderLineItemToInvoiceItem>();

            config.CreateMap<Providers.Provider, Models.ProviderSummaryView>()
                .ForMember(member => member.Address, options => options.MapFrom(source => source.ToDisplayAddress()))
                .ForMember(member => member.ProviderNameSlug, options => options.MapFrom(source => Slug.Create(source.ProviderName, true)));

            config.CreateMap<Providers.Provider, Models.ProviderDetailView>()
                .ForMember(member => member.Address, options => options.MapFrom(source => source.ToDisplayAddress()))
                .ForMember(member => member.AvailableServices, options => options.MapFrom(source => source.AvailableServices.Select(s => s.ServiceType)))
                ;

            // From view model
            config.CreateMap<Models.PersonalDetailsView, PersonalDetails>();
        }

        public static void RegisterMaps(IUnityContainer container)
        {
            container.ResolveAll<IMappingConfig>().ForEach(mapper => mapper.RegisterMapping(AutoMapper.Mapper.Configuration));
        }
    }
}