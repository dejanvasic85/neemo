using System;
using System.Collections.Generic;

namespace Neemo.Store
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
