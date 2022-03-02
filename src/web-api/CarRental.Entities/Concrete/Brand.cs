using System.Collections.Generic;
using CarRental.Entities.Interfaces;

namespace CarRental.Entities.Concrete
{
    public class Brand : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}