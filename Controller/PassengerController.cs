using AirportTicketBookingSystem.Model;
using AirportTicketBookingSystem.Repository;
using AirportTicketBookingSystem.DTO;

namespace AirportTicketBookingSystem.Controllers
{
    public class PassengerController
    {
        private static PassengerController? instance;
        private readonly IPassengerRepository _passengerRepository;


        private PassengerController()
        {
            _passengerRepository = new PassengerRepository();
        }


        public static PassengerController GetInstance()
        {
            if (instance == null)
            {
                instance = new PassengerController();
            }
            return instance;
        }


        public List<PassengerDTO> GetAllPassengers()
        {
            List<Passenger> passengers = _passengerRepository.GetAllPassengers();
            List<PassengerDTO> dtos = new List<PassengerDTO>();
            foreach (Passenger passenger in passengers)
            {
                dtos.Add(PassengerDTO.FromPassenger(passenger));
            }
            return dtos;
        }

        public PassengerDTO? GetPassengerById (int id)
        {
            Passenger? passenger = _passengerRepository.GetPassengerById(id);
            if (passenger != null)
            {
                PassengerDTO? passengerDto = PassengerDTO.FromPassenger(passenger);
                return passengerDto;
            }
            return null;
        }

        public PassengerDTO AddPassenger(int id, string name, string email)
        {
            Passenger? passenger;
            if (_passengerRepository.GetPassengerById(id) != null)
            {
                Console.WriteLine($"Already exists a passenger with id {id}");
                passenger= _passengerRepository.GetPassengerById(id);
            }
            else
            {   
                passenger = new Passenger(id, name, email);
                _passengerRepository.AddPassenger(passenger);
            }
            return (PassengerDTO.FromPassenger(passenger));
        }


    }
}
