using System;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Neemo.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // Register all repository classes automatically
            container.RegisterTypes(
                AllClasses.FromAssemblies(new [] {Assembly.Load("Neemo.DataAccess")}),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            // Register all service class automatically
            container.RegisterTypes(
                AllClasses.FromAssemblies(new[] {Assembly.Load("Neemo")}), 
                WithMappings.FromMatchingInterface,
                WithName.Default);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}