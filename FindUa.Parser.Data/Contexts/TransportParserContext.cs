using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FindUa.Parser.Data.Contexts
{
    public class TransportParserContext : DbContext
    {
        public TransportParserContext(DbContextOptions<TransportParserContext> options)
            : base(options)
        {

        }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DriveUnit> DriveUnits { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<LocalizationKey> LocalizationKeys { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<TransportBrand> Brands { get; set; }
        public DbSet<TransportCondition> TransportConditions { get; set; }
        public DbSet<TransportConditionInSaleAnnounce> TransportConditionInSaleAnnounces { get; set; }
        public DbSet<TransportModel> Models { get; set; }
        public DbSet<TransportSaleAnnounce> SaleAnnounces { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<SourceProvider> SourceProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new BodyTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocalizationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocalizationKeyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SaleAnnounceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransportBrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransportModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransportConditionInSaleAnnounceEntityConfiguration());
        }
    }
}
