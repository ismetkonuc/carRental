using CarRental.Core.DataAccess.Entityframework;
using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.DataAccess.Interfaces;
using CarRental.Entities.Concrete;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfImageRepository : EfGenericRepository<Image, CarRentalDbContext>, IImageDal
    {
        
    }
}