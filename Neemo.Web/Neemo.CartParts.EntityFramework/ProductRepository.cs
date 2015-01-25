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
        public List<Product> SearchProducts(string keyword)
        {
            return FindProduct(p => p.Part.Part1.Contains(keyword));
        }

        public List<Product> GetFeaturedProducts()
        {
            return FindProduct(p => p.Featured == true);
        }

        public List<Product> GetNewProducts()
        {
            return FindProduct(p => p.New == true).ToList();
        }

        public List<Product> GetBestSellingProducts()
        {
            return FindProduct(p => p.TopSeller == true).ToList();
        }

        public Product GetProduct(int id)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbProduct = context.Products
                    .Include(t => t.Part)
                    .Include(t => t.Part.PartPhoto)
                    .Include(t => t.Part.PartPhotoes)
                    .Include(t => t.ProducePrices)
                    .Include(p => p.Wreck)
                    .Include(p => p.Wreck.Make)
                    .First(p => p.ProductId == id);
                
                var product = Mapper.Map<Models.Product, Store.Product>(dbProduct);
                product.Features = new
                {
                    Make = dbProduct.Wreck.Make != null ? dbProduct.Wreck.Make.Make1 : ""
                };

                return product;
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbProduct = context.Products.Single(p => p.ProductId == product.ProductId);
                Mapper.Map(product, dbProduct);
                context.SaveChanges();
            }
        }

        private static List<Product> FindProduct(Expression<Func<Models.Product, bool>> filter)
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
