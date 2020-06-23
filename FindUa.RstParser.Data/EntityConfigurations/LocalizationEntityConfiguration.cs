using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.RstParser.Data.EntityConfigurations
{
    public class LocalizationEntityConfiguration : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LocalizationKey);
        }
    }
}
