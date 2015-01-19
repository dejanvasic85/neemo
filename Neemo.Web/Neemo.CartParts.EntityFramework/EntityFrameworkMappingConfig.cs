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
            config.CreateMap<Neemo.Membership.UserProfile, Models.Registration>().ConvertUsing<UserProfileToRegistrationConverter>();
            

            // From Database
            config.CreateMap<Models.Registration, Membership.UserProfile>().ConvertUsing<RegistrationToUserProfileConverter>();
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
