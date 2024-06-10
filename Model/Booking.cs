using AirportTicketBookingSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Model
{
    public class Booking
    {
        [Required(ErrorMessage = "Booking ID is required.")]
        public string? BookingId { get; set; }

        [Required(ErrorMessage = "Passenger is required.")]
        public Passenger? Passenger { get; set; }

        [Required(ErrorMessage = "Fligh is required.")]
        public Flight? Flight { get; set; }
        [Required(ErrorMessage = "Booking class is required.")]
        public BookingClass BookingClass { get; set; }

        [Required(ErrorMessage = "Date time is required.")]
        public DateTime BookingDate { get; set; }

        public decimal Price { get; set; }



        private decimal GetPriceForBookingClass()
        {
            decimal price;
            switch (BookingClass)
            {
                case BookingClass.Economy:
                    price = Flight.EconomyPrice;
                    break;
                case BookingClass.Business:
                    price = Flight.BusinessPrice;
                    break;
                case BookingClass.FirstClass:
                    price = Flight.FirstClassPrice;
                    break;
                default:
                    throw new ArgumentException("Invalid booking class.");
            }

            return price;
        }


}
}
