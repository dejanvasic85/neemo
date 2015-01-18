using System.Collections.Generic;

namespace Neemo.Store
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string keyword);
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
        List<Product> GetBestSellingProducts();
        Product GetProduct(int id);
    }
}
