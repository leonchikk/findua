using FindUa.Parser.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindUa.Parser.Data.EntityConfigurations
{
    public class TransportModelEntityConfiguration : IEntityTypeConfiguration<TransportModel>
    {
        public void Configure(EntityTypeBuilder<TransportModel> builder)
        {
            builder.ToTable("TransportModels");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Brand)
                   .WithMany(x => x.Models)
                   .HasForeignKey(x => x.BrandId); 
        }
    }
}
