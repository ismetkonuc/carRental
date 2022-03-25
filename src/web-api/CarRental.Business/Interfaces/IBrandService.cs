using CarRental.Core.Utils.Results;
using CarRental.Entities.Concrete;

namespace CarRental.Business.Interfaces
{
    public interface IBrandService : IGenericService<Brand>
    {
        IDataResult<Brand> GetById(int brandId);
    }
}