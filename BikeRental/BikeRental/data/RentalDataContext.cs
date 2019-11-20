using BikeRental.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.data
{
    public class RentalDataContext :DbContext
    {
        public RentalDataContext(DbContextOptions<RentalDataContext> options)
       : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}
