using AirportTicketBookingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.DTO
{
    public record PassengerDTO(int Id, string Name, string Email)
    {
        public static PassengerDTO FromPassenger(Passenger passenger)
        {
            return new PassengerDTO(passenger.Id, passenger.Name, passenger.Email);
        }

        public override string ToString()
        {
            return $"\nPassenger ID: {Id}" +
                   $"\nName: {Name}" +
                   $"\nEmail: {Email}";
        }
    }

}
