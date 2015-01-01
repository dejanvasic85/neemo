namespace Neemo.DataAccess
{
    using System.Collections.Generic;
    using Store;
    
    public class ProductRepository : IProductRepository
    {
        // Todo - Wire up the real backend

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                // Featured
                new Product
                {
                    ProductId = 1, 
                    ImageId="product-1",
                    Images = new []{"product-1","product-2", "product-3"},
                    IsBestSeller = true, 
                    Title = "Cool Light", 
                    Price = 399, 
                    IsFeatured = true,
                    Description = "This should be hooked up to the service, Description!",
                    QuickOverview = "This should be hooked up to the service!",
                    Category = "Mercedes",
                    AvailableQty = 10
                },
                new Product{ ProductId = 2, ImageId="product-2", IsBestSeller = true, Title = "Mercedes Gearbox", Price = 1499, IsFeatured = true},
                new Product{ ProductId = 3, ImageId="product-3", IsBestSeller = true, Title = "Alloy Wheels", Price = 499, IsFeatured = true},
                // New                                         
                new Product{ ProductId = 4, ImageId="product-4", IsBestSeller = true, Title = "Another Allow", Price = 999, IsNew = true},
                new Product{ ProductId = 5, ImageId="product-5", IsBestSeller = true, Title = "8 Spoke Allow", Price = 899, IsNew = true},
                new Product{ ProductId = 6, ImageId="product-6", IsBestSeller = true, Title = "More Wheels man", Price = 499, IsNew = true},
                new Product
                {
                    ProductId = 7, 
                    ImageId="product-1",
                    Images = new []{"product-1","product-2", "product-3"},
                    IsBestSeller = true, 
                    Title = "Product 7", 
                    Price = 399, 
                    IsFeatured = true,
                    Description = "Purpose The foreach binding duplicates a section of markup for each entry in an array, and binds each copy of that markup to the corresponding array item. This is especially useful for rendering lists or tables.",
                    QuickOverview = "Of course, you can arbitrarily nest any number of foreach bindings along with other control-flow ",
                    Category = "Mercedes",
                    AvailableQty = 0
                }
            };
        }
    }
}
