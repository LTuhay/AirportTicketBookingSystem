using AirportTicketBookingSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Model
{
    public class Flight
    {
        [Required(ErrorMessage = "Flight number is required.")]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = "Departure country is required.")]
        [StringLength(20, ErrorMessage = "Departure country cannot exceed 50 characters.")]
        public string DepartureCountry { get; set; }

        [Required(ErrorMessage = "Destination country is required.")]
        [StringLength(20, ErrorMessage = "Destination country cannot exceed 50 characters.")]
        public string DestinationCountry { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        [StringLength(20, ErrorMessage = "Departure airport cannot exceed 100 characters.")]
        public string DepartureAirport { get; set; }

        [Required(ErrorMessage = "Arrival airport is required.")]
        [StringLength(20, ErrorMessage = "Arrival airport cannot exceed 100 characters.")]
        public string ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Economy price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Economy price must be a non-negative number.")]
        public decimal EconomyPrice { get; set; }

        [Required(ErrorMessage = "Business price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Business price must be a non-negative number.")]
        public decimal BusinessPrice { get; set; }

        [Required(ErrorMessage = "First class price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "First class price must be a non-negative number.")]
        public decimal FirstClassPrice { get; set; }

        public Flight(string flightNumber, string departureCountry, string destinationCountry, DateTime departureDate, string departureAirport, string arrivalAirport, decimal economyPrice, decimal businessPrice, decimal firstClassPrice)
        {
            FlightNumber = flightNumber;
            DepartureCountry = departureCountry;
            DestinationCountry = destinationCountry;
            DepartureDate = departureDate;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            EconomyPrice = economyPrice;
            BusinessPrice = businessPrice;
            FirstClassPrice = firstClassPrice;
        }

        public Flight()
        {
            FlightNumber = "New Flight";
            DepartureCountry = "Unknown";
            DestinationCountry = "Unknown";
            DepartureDate = DateTime.Now;
            DepartureAirport = "Unknown";
            ArrivalAirport = "Unknown";
            EconomyPrice = 0;
            BusinessPrice = 0;
            FirstClassPrice = 0;
        }

        public static Flight ToEntity(FlightDTO dto)
        {
            return new Flight
            {
                FlightNumber = dto.FlightNumber,
                DepartureCountry = dto.DepartureCountry,
                DestinationCountry = dto.DestinationCountry,
                DepartureDate = dto.DepartureDate,
                DepartureAirport = dto.DepartureAirport,
                ArrivalAirport = dto.ArrivalAirport,
                EconomyPrice = dto.EconomyPrice,
                BusinessPrice = dto.BusinessPrice,
                FirstClassPrice = dto.FirstClassPrice
            };
        }
    }
}
