using System;
using System.Collections.Generic;

namespace Neemo.Store
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string keyword);
        List<Product> GetFeaturedProducts();
    }
}
