using Microsoft.Practices.Unity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Neemo.Web.Infrastructure;
using Unity.Mvc5;

namespace Neemo.Web
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            
            // Register all repository classes automatically 
            // Register all service classes automatically in the business layer
            
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[]
                {
                    Assembly.Load("Neemo"),
                    Assembly.Load("Neemo.CarParts"),
                    Assembly.Load("Neemo.CarParts.EntityFramework"), 
                }),
                WithMappings.FromMatchingInterface,
                WithName.Default);
            
            // Register ilogger with log4net
            container.RegisterType<ILogger, Log4NetLog>();

            // Register the PayPal payment service ( later we may have a few more :)
            container.RegisterType<Payments.IPaymentService, Payments.pp.PaymentService>();
            
            // FileStore image service requires http utility to initialise
            container.RegisterType<Images.IImageService, Images.FileImageService>(new InjectionConstructor(HttpContext.Current.Server.MapPath("~/"), typeof(ISysConfig)));

            // ICartContext (session based)
            container.RegisterType<ShoppingCart.ICartContext, Infrastructure.SessionCartContext>();

            // Services in website/infrastructure ( including the local mapping config )
            container.RegisterType<Infrastructure.ITemplateService, Infrastructure.TemplateService>();
            container.RegisterType<Shipping.IShippingCalculatorService, Infrastructure.ShippingService>();

            // Register all the assemblies that use the IMapping Config
            container.RegisterType<IMappingConfig, MappingConfig>("WebConfig");
            container.RegisterTypes(new RegisterMappersConvention("Neemo.CarParts.EntityFramework", "Neemo.Payments.PayPal"));
            
            // Set the MVC dependency resolver to use Unity!
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
            return container;
        }
    }
}