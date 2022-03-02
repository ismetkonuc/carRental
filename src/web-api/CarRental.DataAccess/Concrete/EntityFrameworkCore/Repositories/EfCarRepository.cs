using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.Entities.Concrete;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCarRepository : EfGenericRepository<Car, CarRentalDbContext>
    {
        
    }
}