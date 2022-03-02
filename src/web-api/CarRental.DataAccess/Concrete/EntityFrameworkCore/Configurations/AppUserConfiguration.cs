using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Surname).IsRequired();


            builder.HasMany(I => I.Rentals).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId);
        }
    }
}