using System;
using Microsoft.Practices.Unity;

namespace Neemo.Web
{
    public class MappingConfig : IMappingConfig
    {
        public void RegisterConfigs<TMapper>(TMapper mapper)
        {
            if (typeof(TMapper) != typeof(AutoMapper.IConfiguration))
            {
                throw new ArgumentException("TMapper must be of type AutoMapper.Mapper");
            }

            var config = (AutoMapper.IConfiguration)mapper;

            // To view model
            config.CreateMap<Store.Product, Models.ProductSummaryView>()
                .ForMember(member => member.OutOfStock, options => options.ResolveUsing(t => t.IsOutOfStock()));
            config.CreateMap<Store.Product, Models.ProductDetailView>();
            config.CreateMap<Store.ProductCartItem, Models.CartItemView>();
            config.CreateMap<Store.Category, Models.CategoryView>();
            config.CreateMap<Shipping.ShippingCost, Models.ShippingCostView>();
            config.CreateMap<Neemo.Country, Models.CountryView>();
            config.CreateMap<PersonalDetails, Models.PersonalDetailsView>();
            config.CreateMap<Membership.UserProfile, Models.CheckoutView>();
            config.CreateMap<Tax.TaxCost, Models.TaxCostView>();
            config.CreateMap<ShoppingCart.Cart, Models.OrderSummaryView>().ConvertUsing<Models.OrderSummaryConverter>();

            // From view model
            config.CreateMap<Models.PersonalDetailsView, PersonalDetails>();
        }

        public static void RegisterMaps(IUnityContainer container)
        {
            container.ResolveAll<IMappingConfig>()
                .ForEach(mapper => mapper.RegisterConfigs(AutoMapper.Mapper.Configuration));
        }
    }
}