using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FindUa.Parser.Data.Contexts
{
    public class TransportParserContext : DbContext
    {
        public TransportParserContext()
        {

        }

        public TransportParserContext(DbContextOptions<TransportParserContext> options)
            : base(options)
        {

        }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<CarCondition> CarConditions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; } 
        public DbSet<TransportBrand> Brands { get; set; }
        public DbSet<TransportModel> Models { get; set; }
        public DbSet<TransportSaleAnnounce> SaleAnnounces { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocalityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransportModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SaleAnnounceEntityConfiguration());
        }
    }
}
