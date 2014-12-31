using System.Collections.Generic;
using System.Linq;

namespace Neemo.Store
{
    public interface IProductService
    {
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
        List<Product> GetBestSellingProducts();
        Product GetProductById(int id);
        bool CheckAvailability(int productId, int qty);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetFeaturedProducts()
        {
            return _productRepository.GetProducts().Where(p => p.IsNew).ToList();
        }

        public List<Product> GetNewProducts()
        {
            return _productRepository.GetProducts().Where(p => p.IsFeatured).ToList();
        }

        public List<Product> GetBestSellingProducts()
        {
            return _productRepository.GetProducts().Where(p => p.IsBestSeller).ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProducts().FirstOrDefault(p => p.ProductId == id);
        }

        public bool CheckAvailability(int productId, int qty)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return false;

            return product.IsDesiredQuantityAvailable(qty);
        }
    }
}