using System.Data.Entity;
using Neemo.CarParts.EntityFramework.Models.Mapping;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class NeemoContext : DbContext
    {
        static NeemoContext()
        {
            Database.SetInitializer<NeemoContext>(null);
        }

        public NeemoContext()
            : base("Name=NeemoConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        //public DbSet<AncapRating> AncapRatings { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineSize> EngineSizes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<ImageList> ImageLists { get; set; }
        public DbSet<ListingHeader> ListingHeaders { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderStatu> OrderStatus { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartFeature> PartFeatures { get; set; }
        public DbSet<PartPhoto> PartPhotoes { get; set; }
        public DbSet<PartPrice> PartPrices { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WheelBase> WheelBases { get; set; }
        public DbSet<Wreck> Wrecks { get; set; }
        public DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BodyTypeMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ChassisMap());
            modelBuilder.Configurations.Add(new EngineMap());
            modelBuilder.Configurations.Add(new EngineSizeMap());
            modelBuilder.Configurations.Add(new FuelTypeMap());
            modelBuilder.Configurations.Add(new ImageListMap());
            modelBuilder.Configurations.Add(new ListingHeaderMap());
            modelBuilder.Configurations.Add(new MakeMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderHeaderMap());
            modelBuilder.Configurations.Add(new OrderStatuMap());
            modelBuilder.Configurations.Add(new PartMap());
            modelBuilder.Configurations.Add(new PartFeatureMap());
            modelBuilder.Configurations.Add(new PartPhotoMap());
            modelBuilder.Configurations.Add(new PartPriceMap());
            modelBuilder.Configurations.Add(new PriceMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductPriceMap());
            modelBuilder.Configurations.Add(new RegistrationMap());
            modelBuilder.Configurations.Add(new TransmissionMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new WheelBaseMap());
            modelBuilder.Configurations.Add(new WreckMap());
            modelBuilder.Configurations.Add(new YearMap());
        }
    }
}
