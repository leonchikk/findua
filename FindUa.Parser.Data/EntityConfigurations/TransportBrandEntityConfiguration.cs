using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class TransportBrandEntityConfiguration : IEntityTypeConfiguration<TransportBrand>
    {
        public void Configure(EntityTypeBuilder<TransportBrand> builder)
        {
            builder.ToTable("TransportBrands");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.VehicleType);
        }
    }
}
