using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(I => I.Cars).WithOne(I => I.Brand).HasForeignKey(I => I.BrandId);
        }
    }
}