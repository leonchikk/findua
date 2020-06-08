using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class RegionEntityConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                   .WithMany(x => x.Regions)
                   .HasForeignKey(x => x.CountryId);
        }
    }
}
