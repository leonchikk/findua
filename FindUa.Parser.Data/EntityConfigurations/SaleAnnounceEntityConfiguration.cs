using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class SaleAnnounceEntityConfiguration : IEntityTypeConfiguration<TransportSaleAnnounce>
    {
        public void Configure(EntityTypeBuilder<TransportSaleAnnounce> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.BodyType);

            builder.HasOne(x => x.CarCondition);

            builder.HasOne(x => x.TransmissionType);

            builder.HasOne(x => x.EngineType);

            builder.HasOne(x => x.Locality);
        }
    }
}
