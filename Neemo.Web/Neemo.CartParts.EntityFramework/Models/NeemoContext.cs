using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        }

        public DbSet<AncapRating> AncapRatings { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Cylinder> Cylinders { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineSize> EngineSizes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GreenRating> GreenRatings { get; set; }
        public DbSet<ImageList> ImageLists { get; set; }
        public DbSet<Induction> Inductions { get; set; }
        public DbSet<KiloMeter> KiloMeters { get; set; }
        public DbSet<ListingHeader> ListingHeaders { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderStatu> OrderStatus { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartFeature> PartFeatures { get; set; }
        public DbSet<PartPhoto> PartPhotoes { get; set; }
        public DbSet<PartPrice> PartPrices { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<PPlateApprove> PPlateApproves { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Towing> Towings { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleListing> VehicleListings { get; set; }
        public DbSet<VehicleListing_Archive> VehicleListing_Archive { get; set; }
        public DbSet<VehicleListingApproval> VehicleListingApprovals { get; set; }
        public DbSet<VehicleListingDealType> VehicleListingDealTypes { get; set; }
        public DbSet<VehicleListingDealType_Archive> VehicleListingDealType_Archive { get; set; }
        public DbSet<VehicleListingFeature> VehicleListingFeatures { get; set; }
        public DbSet<VehicleListingFeature_Archive> VehicleListingFeature_Archive { get; set; }
        public DbSet<VehicleListingImage> VehicleListingImages { get; set; }
        public DbSet<VehicleListingImage_Archive> VehicleListingImage_Archive { get; set; }
        public DbSet<WheelBase> WheelBases { get; set; }
        public DbSet<Wreck> Wrecks { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Vw_PartDetails_All> Vw_PartDetails_All { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AncapRatingMap());
            modelBuilder.Configurations.Add(new BadgeMap());
            modelBuilder.Configurations.Add(new BodyTypeMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ChassisMap());
            modelBuilder.Configurations.Add(new ColourMap());
            modelBuilder.Configurations.Add(new ConditionMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CylinderMap());
            modelBuilder.Configurations.Add(new DealTypeMap());
            modelBuilder.Configurations.Add(new DoorMap());
            modelBuilder.Configurations.Add(new DriveTypeMap());
            modelBuilder.Configurations.Add(new EngineMap());
            modelBuilder.Configurations.Add(new EngineSizeMap());
            modelBuilder.Configurations.Add(new FeatureMap());
            modelBuilder.Configurations.Add(new FuelTypeMap());
            modelBuilder.Configurations.Add(new GreenRatingMap());
            modelBuilder.Configurations.Add(new ImageListMap());
            modelBuilder.Configurations.Add(new InductionMap());
            modelBuilder.Configurations.Add(new KiloMeterMap());
            modelBuilder.Configurations.Add(new ListingHeaderMap());
            modelBuilder.Configurations.Add(new ListingTypeMap());
            modelBuilder.Configurations.Add(new MakeMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderHeaderMap());
            modelBuilder.Configurations.Add(new OrderStatuMap());
            modelBuilder.Configurations.Add(new PartMap());
            modelBuilder.Configurations.Add(new PartFeatureMap());
            modelBuilder.Configurations.Add(new PartPhotoMap());
            modelBuilder.Configurations.Add(new PartPriceMap());
            modelBuilder.Configurations.Add(new PowerMap());
            modelBuilder.Configurations.Add(new PPlateApproveMap());
            modelBuilder.Configurations.Add(new PriceMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductPriceMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new RegistrationMap());
            modelBuilder.Configurations.Add(new SeatMap());
            modelBuilder.Configurations.Add(new SeriesMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new SuburbMap());
            modelBuilder.Configurations.Add(new TestimonialMap());
            modelBuilder.Configurations.Add(new TowingMap());
            modelBuilder.Configurations.Add(new TransmissionMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehicleListingMap());
            modelBuilder.Configurations.Add(new VehicleListing_ArchiveMap());
            modelBuilder.Configurations.Add(new VehicleListingApprovalMap());
            modelBuilder.Configurations.Add(new VehicleListingDealTypeMap());
            modelBuilder.Configurations.Add(new VehicleListingDealType_ArchiveMap());
            modelBuilder.Configurations.Add(new VehicleListingFeatureMap());
            modelBuilder.Configurations.Add(new VehicleListingFeature_ArchiveMap());
            modelBuilder.Configurations.Add(new VehicleListingImageMap());
            modelBuilder.Configurations.Add(new VehicleListingImage_ArchiveMap());
            modelBuilder.Configurations.Add(new WheelBaseMap());
            modelBuilder.Configurations.Add(new WreckMap());
            modelBuilder.Configurations.Add(new YearMap());
            modelBuilder.Configurations.Add(new Vw_PartDetails_AllMap());
        }
    }
}
