using AirportTicketBookingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.DTO
{
    public record FlightDTO(string FlightNumber, string DepartureCountry, string DestinationCountry, DateTime DepartureDate, string DepartureAirport, string ArrivalAirport, decimal EconomyPrice, decimal BusinessPrice, decimal FirstClassPrice)
    {
        public static FlightDTO FromFlight(Flight flight)
        {
            return new FlightDTO(
                flight.FlightNumber,
                flight.DepartureCountry,
                flight.DestinationCountry,
                flight.DepartureDate,
                flight.DepartureAirport,
                flight.ArrivalAirport,
                flight.EconomyPrice,
                flight.BusinessPrice,
                flight.FirstClassPrice
            );
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Flight Number: {FlightNumber}");
            sb.AppendLine($"Departure Country: {DepartureCountry}");
            sb.AppendLine($"Destination Country: {DestinationCountry}");
            sb.AppendLine($"Departure Date: {DepartureDate.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Departure Airport: {DepartureAirport}");
            sb.AppendLine($"Arrival Airport: {ArrivalAirport}");

            if (EconomyPrice != 0)
                sb.AppendLine($"Economy Price: {EconomyPrice}");
            if (BusinessPrice != 0)
                sb.AppendLine($"Business Price: {BusinessPrice}");
            if (FirstClassPrice != 0)
                sb.AppendLine($"First Class Price: {FirstClassPrice}");

            return sb.ToString();
        }
    }

}
