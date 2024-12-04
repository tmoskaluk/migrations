using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Customers.Crud.Models;

internal class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.IdentityNo).IsUnique();

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CustomerType).IsRequired();
        builder.Property(x => x.IdentityNo).HasMaxLength(Customer.IdentityNoMaxLength).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(Customer.NameMaxLength).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(Customer.NameMaxLength).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(Customer.PhoneMaxLength).IsRequired();
    }
}