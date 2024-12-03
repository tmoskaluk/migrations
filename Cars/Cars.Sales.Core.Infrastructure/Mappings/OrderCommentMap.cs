using Cars.Sales.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Sales.Core.Infrastructure.Mappings;

internal class OrderCommentMap : IEntityTypeConfiguration<OrderComment>
{
    public void Configure(EntityTypeBuilder<OrderComment> builder)
    {
        builder.ToTable("OrderComments");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.Comment).HasMaxLength(255).IsRequired();
    }
}