namespace Neemo.Web
{
    using Images;
    using Infrastructure;
    using Microsoft.Practices.Unity;
    using Shipping;
    using ShoppingCart;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using Unity.Mvc5;
    
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            
            // Register all repository classes automatically
            const string carPartsDataLayerName = "Neemo.CarParts.EntityFramework";
            
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[]
                {
                    Assembly.Load(carPartsDataLayerName)
                }),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterTypes(new RegisterMappersConvention(carPartsDataLayerName));

            
            // Register all service class automatically
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[]
                {
                    Assembly.Load("Neemo")
                }),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            // FileStore image service requires http utility to initialise
            container.RegisterType<IImageService, FileImageService>(
                new InjectionConstructor(HttpContext.Current.Server.MapPath("~/"), typeof(ISysConfig)));

            // ICartContext (session based)
            container.RegisterType<ICartContext, SessionCartContext>();

            // Services in website/infrastructure ( including the local mapping config )
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IShippingCalculatorService, ShippingService>();
            container.RegisterType<IMappingConfig, Neemo.Web.MappingConfig>("WebConfig");

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
            return container;
        }
    }
}