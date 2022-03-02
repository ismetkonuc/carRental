using System.Collections.Generic;
using System.Security.AccessControl;
using CarRental.Entities.Interfaces;

namespace CarRental.Entities.Concrete
{
    public class Image : IBaseEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public List<Car> Cars { get; set; }
    }
}