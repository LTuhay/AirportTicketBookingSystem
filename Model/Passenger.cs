using AirportTicketBookingSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AirportTicketBookingSystem.Model
{
    public class Passenger 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Passenger(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Passenger()
        {
            Id = -1;
            Name = "New Passenger";
            Email = "New Email";
        }

        public static Passenger ToEntity(PassengerDTO dto)
        {
            return new Passenger
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };
        }
    }


}
