using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();


            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Price).IsRequired();
            builder.Property(I => I.Year).IsRequired();
            builder.Property(I => I.CarType).IsRequired();
            builder.Property(I => I.FuelType).IsRequired();
            builder.Property(I => I.GearType).IsRequired();


            builder.HasMany(I => I.Images).WithMany(I => I.Cars);
        }
    }
}