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


            // From Database
            config.CreateMap<Models.Category, Neemo.Store.Category>()
                .ForMember(m => m.ParentId, options => options.Ignore())
                .ForMember(m => m.CategoryId, options => options.MapFrom(src => src.CategoryID))
                .ForMember(m => m.Title, options => options.MapFrom(src => src.Category1))
                ;

            config.CreateMap<Models.Product, Neemo.Store.Product>()
                .ForMember(m => m.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(m => m.IsNew, options => options.MapFrom(src => src.New))
                .ForMember(m => m.Features, options => options.MapFrom(src => src.Featured))
                .ForMember(m => m.IsBestSeller, options => options.MapFrom(src => src.TopSeller))
                .ForMember(m => m.AvailableQty, options => options.MapFrom(src => src.Qty))
                .ForMember(m => m.Features, options => options.Ignore())
                .ForMember(m => m.IsAvailable, options => options.MapFrom(s => !s.Soldout))
                .ForMember(m => m.Price, options => options.MapFrom(source => source.ProducePrices.First().Price))
                ;

            // To Database
        }
    }
}
