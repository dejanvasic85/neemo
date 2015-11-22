using System.Collections.Generic;
using AutoMapper;

namespace Neemo.Web
{
    public class ProductSpecificationConverter : ValueResolver<Store.Product, Dictionary<string, string>>
    {
        protected override Dictionary<string, string> ResolveCore(Store.Product source)
        {
            var dictionary = source.ProductSpecifications.ToDictionary<string>();
            
            return dictionary as Dictionary<string, string>;
        }
    }
}