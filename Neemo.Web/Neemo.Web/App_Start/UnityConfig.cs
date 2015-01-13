namespace Neemo.Web
{
    using Images;
    using Infrastructure;
    using Microsoft.Practices.Unity;
    using Shipping;
    using ShoppingCart;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[]
                {
                    Assembly.Load("Neemo.CarParts.EntityFramework")
                }),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            //container.RegisterTypes()

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
            container.RegisterTypes(new RegisterMappersConvention("Neemo.CarParts.EntityFramework"));
            return container;
        }
    }

    public class RegisterMappersConvention : RegistrationConvention
    {
        private readonly string[] _assembliesToPoke;

        public RegisterMappersConvention(params string[] assembliesToPoke)
        {
            _assembliesToPoke = assembliesToPoke;
        }

        public override IEnumerable<Type> GetTypes()
        {
            var types = new List<Type>();

            // Gets all types from required assemblies
            foreach (var assembly in _assembliesToPoke)
            {
                types.AddRange( Assembly.Load(assembly).GetTypes().Where(t => t.GetInterfaces().Any( i => i == typeof(IMappingConfig)) ));
            }

            return types;
        }

        public override Func<Type, IEnumerable<Type>> GetFromTypes()
        {
            // Adds a filter returned from the GetTypes method
            return t =>
            {
                return t.GetTypeInfo().ImplementedInterfaces;
            };
        }

        public override Func<Type, string> GetName()
        {
            return t => t.Name;
        }

        public override Func<Type, LifetimeManager> GetLifetimeManager()
        {
            return t => new ContainerControlledLifetimeManager();
        }

        public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
        {
            return null;
        }
    }
}