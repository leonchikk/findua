using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class LocalityEntityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Region)
                   .WithMany(x => x.Localities)
                   .HasForeignKey(x => x.RegionId);
        }
    }
}
