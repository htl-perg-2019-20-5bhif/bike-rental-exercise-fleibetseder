using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int BikeId { get; set; }

        public Bike Bike { get; set; }

        [Required]
        public DateTime RentalBegin { get; set; }

        private DateTime RentalEndValue = DateTime.MaxValue;

        public DateTime RentalEnd
        {
            get { return RentalEndValue; }
            set
            {
                if (RentalBegin >= value)
                {
                    throw new ArgumentException("Rental end must be after rental start!");
                }
                RentalEndValue = value;
            }
        }

        private double TotalValue = double.MinValue;

        [Range(minimum: 0, maximum: double.MaxValue)]
        public double Total
        {
            get { return TotalValue; }
            set
            {
                TotalValue = Math.Round(value, 2);
            }
        }

        private Boolean PaidValue;

        [Required]
        public Boolean Paid
        {
            get { return PaidValue; }
            set
            {
                if ((RentalEnd == DateTime.MaxValue) && value)
                {
                    throw new ArgumentException("Ride must have ended before you can pay!");
                }
                PaidValue = value;
            }
        }
    }
}
