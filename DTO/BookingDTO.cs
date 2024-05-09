using AirportTicketBookingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.DTO
{
    public record BookingDTO(string BookingId, PassengerDTO Passenger, FlightDTO Flight, string BookingClass, DateTime BookingDate, decimal BookingPrice)
    {
        public static BookingDTO FromBooking(Booking booking)
        {
            return new BookingDTO(
                booking.BookingId,
                PassengerDTO.FromPassenger(booking.Passenger),
                FlightDTO.FromFlight(booking.Flight),
                booking.BookingClass.ToString(),
                booking.BookingDate,
                booking.Price
            );
        }
        public override string ToString()
        {
            return $"Booking ID: {BookingId}" +
                   $"\nPassenger: {Passenger}" +
                   $"\nFlight: {Flight}" +
                   $"Booking Class: {BookingClass}" +
                   $"\nBooking Date: {BookingDate.ToString("dd/MM/yyyy")}"+
                   $"\nBooking Price: {BookingPrice}";
        }
    }

}
