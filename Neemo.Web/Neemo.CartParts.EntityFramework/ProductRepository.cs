namespace Neemo.CarParts.EntityFramework
{
    using AutoMapper;
    using Store;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return ProductDatabaseList(p => p != null);
        }

        public List<Product> SearchProducts(string keyword)
        {
            return ProductDatabaseList(p => p.Part.Part1.Contains(keyword));
        }

        public List<Product> GetFeaturedProducts()
        {
            return ProductDatabaseList(p => p.Featured == true);
        }

        public List<Product> GetNewProducts()
        {
            return ProductDatabaseList(p => p.New == true).ToList();
        }

        public List<Product> GetBestSellingProducts()
        {
            return ProductDatabaseList(p => p.TopSeller == true).ToList();
        }

        public Product GetProduct(int id)
        {
            return ProductDatabaseList(p => p.ProductId == id).FirstOrDefault();
        }

        private static List<Product> ProductDatabaseList(Expression<Func<Models.Product, bool>> filter)
        {
            using (var context = DbContextFactory.Create())
            {
                var productModels = context.Products
                    .Where(filter)
                    .Include(t => t.Part)
                    .Include(t => t.Part.PartPhoto)
                    .Include(t => t.Part.PartPhotoes)
                    .Include(t => t.ProducePrices)
                    .ToList();


                var featuredProducts = productModels
                    .Select(Mapper.Map<Models.Product, Store.Product>)
                    .ToList();

                return featuredProducts;
            }
        }
    }
}
