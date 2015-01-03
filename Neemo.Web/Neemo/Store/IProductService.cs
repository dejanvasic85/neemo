using System.Collections.Generic;
using System.Linq;

namespace Neemo.Store
{
    public interface IProductService
    {
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
        List<Product> GetBestSellingProducts();
        List<Product> Search(string keyword);
        Product GetProductById(int id);
        bool IsAvailable(int productId, int desiredQuantity, int? bookedQuantity);
        bool IsInStock(int productId);
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

        public List<Product> Search(string keyword)
        {
            return _productRepository.SearchProducts(keyword);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProducts().FirstOrDefault(p => p.ProductId == id);
        }

        public bool IsAvailable(int productId, int desiredQuantity, int? bookedQuantity)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return false;

            return product.AvailableQty - (desiredQuantity + bookedQuantity.GetValueOrDefault()) >= 0;
        }

        public bool IsInStock(int productId)
        {
            // Should return true if there is at least one in there!
            return IsAvailable(productId, 1, bookedQuantity: null);
        }

    }
}