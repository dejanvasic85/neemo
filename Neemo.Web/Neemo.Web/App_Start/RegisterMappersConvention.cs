using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace Neemo.Web
{
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