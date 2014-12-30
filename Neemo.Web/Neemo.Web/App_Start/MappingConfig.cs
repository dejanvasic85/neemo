using AutoMapper;

namespace Neemo.Web
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<Store.Product, Models.ProductSummaryView>();
        }
    }
}