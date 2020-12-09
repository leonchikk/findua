using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FindUa.Parser.Data.EntityConfigurations
{
    class BodyTypeEntityConfiguration : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.VehicleType);
        }
    }
}
