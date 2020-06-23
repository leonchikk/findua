using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.RstParser.Data.EntityConfigurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Region)
                   .WithMany(x => x.Cities)
                   .HasForeignKey(x => x.RegionId);

            builder.HasOne(x => x.LocalizationKey);
        }
    }
}
