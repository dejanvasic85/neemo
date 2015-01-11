using AutoMapper;

namespace Neemo.Web
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {

            Mapper.CreateMap<Store.Product, Models.ProductSummaryView>()
                .ForMember(member => member.OutOfStock, options => options.ResolveUsing(t =>  t.IsOutOfStock()));
            Mapper.CreateMap<Store.Product, Models.ProductDetailView>();
            Mapper.CreateMap<Store.ProductCartItem, Models.CartItemView>();
            Mapper.CreateMap<Store.Category, Models.CategoryView>();
            Mapper.CreateMap<Shipping.ShippingCost, Models.ShippingCostView>();
            Mapper.CreateMap<Neemo.Country, Models.CountryView>();
            Mapper.CreateMap<Membership.PersonalDetails, Models.PersonalDetailsView>();
            Mapper.CreateMap<Membership.UserProfile, Models.CheckoutView>();

        }
    }
}