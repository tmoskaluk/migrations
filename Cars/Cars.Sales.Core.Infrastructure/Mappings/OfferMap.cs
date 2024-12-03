using Cars.Sales.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Sales.Core.Infrastructure.Mappings;

internal class OfferMap : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreationDate).IsRequired();
        builder.Property(o => o.TotalPrice).IsRequired().HasColumnType(SalesDbContext.DbMoneyType);
        builder.Property(o => o.ExpirationDate).IsRequired();
        builder.OwnsOne(o => o.Configuration, o =>
        {
            o.OwnsOne(c => c.Engine, c =>
            {
                c.Property(e => e.Type).IsRequired();
                c.Property(e => e.Capacity).IsRequired();
                c.Property(e => e.Code).IsRequired();
            });
        });
    }
}