using System.Collections.Generic;

namespace Neemo.Store
{
    public interface IProductRepository
    {
        List<Product> SearchProducts(string keyword, decimal? priceMin, decimal? priceMax, int? categoryId, int? makeId, int? modelId, string chassis, string engineNo, int? engineSizeId, int? fuelTypeId, int? bodyTypeId, int? wheelBaseId, int? yearMin, int? yearMax);
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
        List<Product> GetBestSellingProducts();
        Product GetProduct(int id);
        void UpdateProduct(Product product);
    }
}
