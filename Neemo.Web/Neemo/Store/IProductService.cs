using System.Collections.Generic;
using System.Linq;
using Neemo.ShoppingCart;

namespace Neemo.Store
{
    public interface IProductService
    {
        List<Product> GetFeaturedProducts();
        List<Product> GetNewProducts();
        List<Product> GetBestSellingProducts();
        List<Product> Search(string keyword, decimal? priceMin, decimal? priceMax, int? categoryId, int? makeId, int? modelId, string chassis, string engineNo, int? engineSizeId, int? fuelTypeId, int? bodyTypeId, int? wheelBaseId, int? yearMin, int? yearMax);
        Product GetProductById(int id);
        bool IsAvailable(int productId, int desiredQuantity, int? bookedQuantity);
        bool IsInStock(int productId);

        /// <summary>
        /// The shopping cart is 'processed' by adjusting the stock levels for each item
        /// </summary>
        void AdjustStockLevels(Cart shoppingCart);

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
            return _productRepository.GetFeaturedProducts();
        }

        public List<Product> GetNewProducts()
        {
            return _productRepository.GetNewProducts();
        }

        public List<Product> GetBestSellingProducts()
        {
            return _productRepository.GetBestSellingProducts();
        }

        public List<Product> Search(string keyword, decimal? priceMin, decimal? priceMax, int? categoryId, int? makeId, int? modelId, string chassis, string engineNo, int? engineSizeId, int? fuelTypeId, int? bodyTypeId, int? wheelBaseId, int? yearMin, int? yearMax)
        {
            return _productRepository.SearchProducts(keyword, priceMin, priceMax, categoryId, makeId, modelId, chassis, engineNo, engineSizeId, fuelTypeId, bodyTypeId, wheelBaseId, yearMin, yearMax);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public bool IsAvailable(int productId, int desiredQuantity, int? bookedQuantity)
        {
            var product = GetProductById(productId);
            if (product == null)
                return false;

            return product.AvailableQty - (desiredQuantity + bookedQuantity.GetValueOrDefault()) >= 0;
        }

        public bool IsInStock(int productId)
        {
            // Should return true if there is at least one in there!
            return IsAvailable(productId, 1, bookedQuantity: null);
        }

        public void AdjustStockLevels(Cart shoppingCart)
        {
            // Create the order records


            // Each product should have their stock adjusted
            shoppingCart.GetItems().ForEach(soldProduct =>
            {
                var product = _productRepository.GetProduct(soldProduct.Id);

                product.ReduceQuantity(soldProduct.Quantity);

                _productRepository.UpdateProduct(product);
            });
        }
    }
}