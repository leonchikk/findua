using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class SaleAnnounceEntityConfiguration : IEntityTypeConfiguration<TransportSaleAnnounce>
    {
        public void Configure(EntityTypeBuilder<TransportSaleAnnounce> builder)
        {
            builder.ToTable("TransportSaleAnnounces");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.BodyType);

            builder.HasOne(x => x.TransmissionType);

            builder.HasOne(x => x.FuelType);

            builder.HasOne(x => x.Model);

            builder.HasOne(x => x.City);

            builder.HasOne(x => x.DriveUnit);
        }
    }
}
