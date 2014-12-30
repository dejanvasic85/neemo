using System.Collections.Generic;
using System.Linq;

namespace Neemo.Store
{
    public interface IProductService
    {
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
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
    }
}