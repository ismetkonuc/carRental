using CarRental.Core.Entities;
using System.Collections.Generic;


namespace CarRental.Entities.Concrete
{
    public class Image : IBaseEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public List<Car> Cars { get; set; }
    }
}