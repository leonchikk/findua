using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FindUa.RstParser.Data.EntityConfigurations
{
    public class LocalizationKeyEntityConfiguration : IEntityTypeConfiguration<LocalizationKey>
    {
        public void Configure(EntityTypeBuilder<LocalizationKey> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
