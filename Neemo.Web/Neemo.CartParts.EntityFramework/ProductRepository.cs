using System.Data;

namespace Neemo.CarParts.EntityFramework
{
    using AutoMapper;
    using Dapper;
    using Store;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductRepository : IProductRepository
    {
        public List<Product> SearchProducts(string keyword, decimal? priceMin, decimal? priceMax, int? categoryId, int? makeId, int? modelId, string chassis, string engineNo, int? engineSizeId, int? fuelTypeId, int? bodyTypeId, int? wheelBaseId, int? yearMin, int? yearMax)
        {
            using (var context = DbContextFactory.Create())
            {
                // Call dapper to make the proc call but just use the EntityFramework connection
                var products = context.Database.Connection.Query<Product>("Product_Search", new
                {
                    keyword,
                    priceMin,
                    priceMax,
                    categoryId,
                    makeId,
                    modelId,
                    chassis,
                    engineNo,
                    engineSizeId,
                    fuelTypeId,
                    bodyTypeId,
                    wheelBaseId,
                    yearMin,
                    yearMax
                }, commandType: CommandType.StoredProcedure).ToList();

                return products;
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
                // Call dapper to make the proc call but just use the EntityFramework connection
                var dbProduct = context.Database.Connection
                    .Query("select * from vw_productAll_Web where ProductId = @productId", new { productId = id }, commandType: CommandType.Text)
                    .Single();

                var images = context.Database.Connection
                    .Query("ProductPartPhotos_get", new { ProductID = id, PartID = dbProduct.PartID }, commandType: CommandType.StoredProcedure)
                    .ToList();

                var product = new Product
                {
                    ProductId = dbProduct.ProductId,
                    AvailableQty = dbProduct.AvailableQty,
                    Title = dbProduct.Title,
                    QuickOverview = dbProduct.QuickOverview,
                    ImageId = dbProduct.ImageId,
                    IsAvailable = dbProduct.IsAvailable == 1 ? true : false,
                    IsNew = (bool)dbProduct.New,
                    IsBestSeller = (bool)dbProduct.TopSeller,
                    IsFeatured = (bool)dbProduct.Featured,
                    CategoryId = dbProduct.CategoryID,
                    Price = dbProduct.Price,
                    Description = dbProduct.Description,
                    CreatedDateTime = dbProduct.CreatedDateTime,
                    Images = images.Select(i => (string)i.PhotoName).ToArray(),
                    ProductSpecifications = new
                    {
                        Make = dbProduct.Make,
                        Model = dbProduct.Model,
                        Chassis = dbProduct.ChassisNo,
                        Engine = dbProduct.EngineSize,
                        EngineNo = dbProduct.EngineNo,
                        FuelType = dbProduct.FuelType,
                        WheelBase = dbProduct.WheelBase,
                        Body = dbProduct.BodyType,
                        Year = dbProduct.Year,
                    },

                    OtherDetails = new
                    {
                        PartNo = dbProduct.PartNo,
                        Part = dbProduct.Part,
                        Height = dbProduct.Height,
                        Width = dbProduct.Width,
                        Length = dbProduct.Length,
                        Weight = dbProduct.Weight,
                        Colour = dbProduct.Colour,
                        Side = dbProduct.Side
                    },
                    DefectNotes = dbProduct.DeffectNotes

                };


                //// Todo - move this possibly elsewhere?

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

                var products = productModels
                    .Select(Mapper.Map<Models.Product, Store.Product>)
                    .ToList();

                return products;
            }
        }
    }
}
