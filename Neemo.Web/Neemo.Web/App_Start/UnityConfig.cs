using Neemo.Shipping;

namespace Neemo.Web
{
    using Images;
    using Infrastructure;
    using Microsoft.Practices.Unity;
    using ShoppingCart;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register all repository classes automatically
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[] {Assembly.Load("Neemo.DataAccess")}),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            // Register all service class automatically
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[] {Assembly.Load("Neemo")}),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            // FileStore image service requires http utility to initialise
            container.RegisterType<IImageService, FileImageService>(
                new InjectionConstructor(HttpContext.Current.Server.MapPath("~/"), typeof(ISysConfig)));

            // ICartContext (session based)
            container.RegisterType<ICartContext, SessionCartContext>();

            // Services in website/infrastructure
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IShippingCalculatorService, ShippingCalculator>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}