using CarRental.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using CarRental.Entities.Concrete;

namespace CarRental.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRentalRepository : EfGenericRepository<Rental, CarRentalDbContext>
    {
        
    }
}