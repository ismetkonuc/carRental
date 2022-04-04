﻿using System;
using CarRental.Core.Entities;

namespace CarRental.Entities.Dtos.Rental
{
    public class RentalInsertDto : IDto
    {
        public DateTime ReservationDate { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CarId { get; set; }
        public int AppUserId { get; set; }
    }
}