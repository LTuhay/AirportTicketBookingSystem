using AirportTicketBookingSystem.DTO;
using AirportTicketBookingSystem.Model;
using AirportTicketBookingSystem.Repository;

namespace AirportTicketBookingSystem.Controller
{
    public class BookingController
    {
        private static BookingController? instance;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IBookingRepository _bookingRepository;


        private BookingController()
        {
            _flightRepository = new FlightRepository();
            _passengerRepository = new PassengerRepository();
            _bookingRepository = new BookingRepository(_passengerRepository, _flightRepository);
        }

        public static BookingController GetInstance()
        {
            if (instance == null)
            {
                instance = new BookingController();
            }
            return instance;
        }

        public void BatchFlightUpload(string filePath)
        {
            _flightRepository.BatchFlightUpload(filePath);
        }


        public List<FlightDTO> GetAllFlights()
        {
            List<Flight>flights = _flightRepository.GetAllFlights();
            List<FlightDTO> dto = new List<FlightDTO>();
            foreach (Flight flight in flights)
            {
                dto.Add(FlightDTO.FromFlight(flight));
            }
            return dto;
        }

        public List<BookingDTO> GetBookingsByPassenger(int passengerId)
        {
            List<Booking> bookings = _bookingRepository.GetBookingsByPassenger(passengerId);
            List<BookingDTO> dto = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                dto.Add(BookingDTO.FromBooking(booking));
            }
            return dto;
        }

        public FlightDTO? GetFlightsByNumber(string number)
        {
            Flight? flight = _flightRepository.GetFlightByNumber(number);
            if (flight != null)
            {
                return FlightDTO.FromFlight(flight);
            }

            return null;
        }
        public List<FlightDTO> GetFlightsByParams(decimal minPrice, decimal maxPrice, string? departure, string? destination, DateTime departureDate, string? departureAirport, string? destinationAirport, string? travelClass)
        {
            List<Flight> flights = _flightRepository.GetFlightByParams(minPrice, maxPrice, departure, destination, departureDate, departureAirport, destinationAirport, travelClass);
            List<FlightDTO> dto = new List<FlightDTO>();
            foreach (Flight flight in flights)
            {
                dto.Add(FlightDTO.FromFlight(flight));
            }
            return dto;
        }

        public List<BookingDTO> GetBookingsByParams(decimal minPrice, decimal maxPrice, string? departure, string? destination, DateTime departureDate, string? departureAirport, string? destinationAirport, string? travelClass)
        {
            List<Booking> bookings = _bookingRepository.GetBookingByParams(minPrice, maxPrice, departure, destination, departureDate, departureAirport, destinationAirport, travelClass);
            List<BookingDTO> dto = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                dto.Add(BookingDTO.FromBooking(booking));
            }
            return dto;
        }

        public List<BookingDTO> GetAllBookings() 
        { 
            List<Booking> bookings = _bookingRepository.GetAllBookings();
            List<BookingDTO> dto = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                dto.Add(BookingDTO.FromBooking(booking));
            }
            return dto;
        }

        public Guid GenerateUniqueBookingId()
        {

            Guid bookingId = Guid.NewGuid();
            List<Booking> bookings = _bookingRepository.GetAllBookings();

            while (bookings.Exists(booking => booking.BookingId.Equals(bookingId)))
            {
                bookingId = Guid.NewGuid();
            }

            return bookingId;
        }

        public void AddBooking (BookingDTO booking)
        {
            _bookingRepository.AddBooking(Booking.ToEntity(booking));
        }


        public List<BookingDTO> GetBookingsByFlightNumber(string flightNumber)
        {
            List<Booking> bookings = _bookingRepository.GetBookingByFlightNumber(flightNumber);
            List<BookingDTO> dto = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                dto.Add(BookingDTO.FromBooking(booking));
            }
            return dto;
        }

        public BookingDTO? GetBookingById(string id)
        {
            Booking? booking = _bookingRepository.GetBookingByID(id);
            if (booking != null)
            {
                return BookingDTO.FromBooking(booking);
            }
            return null;
        }

        public void DeleteBookingById(string id)
        {
            _bookingRepository.DeleteBooking(id);
        }

        public void UpdateBooking(BookingDTO booking)
        {
            _bookingRepository.UpdateBooking(Booking.ToEntity(booking));
        }

        public void ImportConstraints()
        {
            Console.WriteLine("Flight Import Constraints:");
            Console.WriteLine();

            Console.WriteLine("1. Flight Number:");
            Console.WriteLine("   - Required: Each flight must have a unique flight number.");
            Console.WriteLine();

            Console.WriteLine("2. Departure and Destination Country:");
            Console.WriteLine("   - Required: Departure and destination country must be specified for each flight.");
            Console.WriteLine("   - Length Limit: Country names cannot exceed 20 characters.");
            Console.WriteLine();

            Console.WriteLine("3. Departure Date:");
            Console.WriteLine("   - Required: Departure date for each flight is mandatory.");
            Console.WriteLine("   - Format: Date should be in the correct format (DD/MM/YYYY HH:MM).");
            Console.WriteLine("   - Allowed Range: Departure date must be in the future.");
            Console.WriteLine();

            Console.WriteLine("4. Departure and Arrival Airport:");
            Console.WriteLine("   - Required: Departure and arrival airport must be provided for each flight.");
            Console.WriteLine("   - Length Limit: Airport names cannot exceed 20 characters.");
            Console.WriteLine();

            Console.WriteLine("5. Economy, Business, and First Class Price:");
            Console.WriteLine("   - Optional: If a class is not available on a flight, the price should be set to 0.");
            Console.WriteLine("   - Price Range: Prices must be non-negative numbers.");
        }




    }
}
