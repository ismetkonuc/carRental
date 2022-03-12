using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CarRental.Business.Interfaces
{
    public interface IRentalService : IGenericService<Rental>
    {
        
    }
}