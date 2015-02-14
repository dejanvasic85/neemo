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
            using (var context = DbContextFactory.Create())
            {
                // Todo - call a stored procedure instead
                var dbProducts = context.Products
                        .Include(t => t.Part)
                        .Include(t => t.Part.PartPhoto)
                        .Include(t => t.Part.PartPhotoes)
                        .Include(t => t.ProducePrices)
                        .Include(p => p.Wreck)
                        .Include(p => p.Wreck.Make)
                        .Include(p => p.Wreck.Model)
                        .Include(p => p.Wreck.Chassis)
                        .Include(p => p.Wreck.EngineSize)
                        .Include(p => p.Wreck.FuelType)
                        .Include(p => p.Wreck.WheelBase)
                        .Include(p => p.Wreck.BodyType)
                        .Include(p => p.Wreck.Year)
                        .ToList();

                var items = dbProducts.Select(Mapper.Map<Models.Product, Store.Product>).ToList();

                return items;
            }
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
                    .Include(p => p.Wreck.Model)
                    .Include(p => p.Wreck.Chassis)
                    .Include(p => p.Wreck.EngineSize)
                    .Include(p => p.Wreck.FuelType)
                    .Include(p => p.Wreck.WheelBase)
                    .Include(p => p.Wreck.BodyType)
                    .Include(p => p.Wreck.Year)
                    .FirstOrDefault(p => p.ProductId == id && p.Active == true);

                if (dbProduct == null)
                    return null;

                var product = Mapper.Map<Models.Product, Store.Product>(dbProduct);

                // Todo - move this possibly elsewhere?
                product.ProductSpecifications = new
                {
                    Make = dbProduct.Wreck.Make != null ? dbProduct.Wreck.Make.Make1 : "",
                    Model = dbProduct.Wreck.Model != null ? dbProduct.Wreck.Model.Model1 : "",
                    Chassis = dbProduct.Wreck.Chassis != null ? dbProduct.Wreck.Chassis.ChassisNo : "",
                    EngineSie = dbProduct.Wreck.EngineSize != null ? dbProduct.Wreck.EngineSize.EngineSize1 : "",
                    FuelType = dbProduct.Wreck.FuelType != null ? dbProduct.Wreck.FuelType.FuelType1 : "",
                    WheelBase = dbProduct.Wreck.WheelBase != null ? dbProduct.Wreck.WheelBase.WheelBase1 : "",
                    Body = dbProduct.Wreck.BodyType != null ? dbProduct.Wreck.BodyType.BodyType1 : "",
                    Year = dbProduct.Wreck.Year != null ? dbProduct.Wreck.Year.Year1 : "",
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
