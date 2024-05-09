using AirportTicketBookingSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Model
{
    public class Booking
    {
        public string? BookingId { get; set; }
        public Passenger? Passenger { get; set; }
        public Flight? Flight { get; set; }
        public BookingClass BookingClass { get; set; }
        public DateTime BookingDate { get; set; }

        public decimal Price { get; set; }


 

        public override string ToString()
        {
            return $"Booking ID: {BookingId}\n" +
                   $"Passenger: {Passenger}\n" +
                   $"Flight: {Flight}\n" +
                   $"Class: {BookingClass}\n" +
                   $"Booking Date: {BookingDate}\n" +
                   $"Booking Price: {Price}";
        }

        public Booking()
        {
            BookingId = null;
            Passenger = new Passenger();
            Flight = new Flight();
            BookingClass = BookingClass.Economy;
            BookingDate = DateTime.Now;
            Price = GetPriceForBookingClass();
        }

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


        public static Booking ToEntity(BookingDTO dto)
    {

        Booking booking = new Booking
        {
            BookingId = dto.BookingId,
            Passenger = Passenger.ToEntity(dto.Passenger),
            Flight = Flight.ToEntity(dto.Flight),
            BookingClass = Enum.Parse<BookingClass>(dto.BookingClass),
            BookingDate = dto.BookingDate,
            Price = dto.BookingPrice
        };


        return booking;
    }
}
}
