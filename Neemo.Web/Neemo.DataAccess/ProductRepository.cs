using Neemo.Store;
using System.Collections.Generic;

namespace Neemo.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        // Todo - Wire up the real backend

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ ProductId = 1, Title = "Lorem ipsum dolor"}
            };
        }
    }
}
