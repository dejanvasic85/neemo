using AutoMapper;

namespace Neemo.Web
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<Store.Product, Models.ProductSummaryView>()
                .ForMember(member => member.OutOfStock, options => options.ResolveUsing(t => t.AvailableQty == 0));
            Mapper.CreateMap<Store.Product, Models.ProductDetailView>();
            Mapper.CreateMap<Store.ProductCartItem, Models.CartItemView>();
            Mapper.CreateMap<Store.Category, Models.CategoryView>();
            Mapper.CreateMap<Shipping.ShippingCost, Models.ShippingCostView>();
        }
    }
}