using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.RstParser.Data.EntityConfigurations
{
    public class TransportConditionInSaleAnnounceEntityConfiguration : IEntityTypeConfiguration<TransportConditionInSaleAnnounce>
    {
        public void Configure(EntityTypeBuilder<TransportConditionInSaleAnnounce> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SaleAnnounce)
                .WithMany(x => x.TransportConditions)
                .HasForeignKey(x => x.SaleAnnounceId);
        }
    }
}
