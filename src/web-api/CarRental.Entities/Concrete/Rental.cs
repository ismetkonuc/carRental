using System;
using CarRental.Core.Entities;

namespace CarRental.Entities.Concrete
{
    public class Rental : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public int CarId { get; set; }
        public Car Car { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}