using AirportTicketBookingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private string filePath = @"..\..\..\Data\PeopleData.txt";
        private List<Passenger> passengers;

        public PassengerRepository()
        {
            passengers = new List<Passenger>();
            PassengerUpload(filePath);

        }

        void IPassengerRepository.BatchFlightUpload(string fp) // Uploads file with passengers info when system is initiated
        {
            PassengerUpload(fp);
        }

        private void PassengerUpload(string fp)  
        {

            try
            {
                using (StreamReader reader = new StreamReader(fp))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] parts = line.Split(',');
                        if (parts.Length >= 3)
                        {

                            Passenger passenger = new Passenger
                            {
                                Id = int.Parse(parts[0]),
                                Name = parts[1],
                                Email = parts[2]
                            };


                            passengers.Add(passenger);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

        }

        Passenger? IPassengerRepository.GetPassengerById(int passengerId)
        {
            return passengers.FirstOrDefault(passenger => passenger.Id == passengerId);
        }
        void IPassengerRepository.AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            string line = $"{passenger.Id},{passenger.Name},{passenger.Email}\n";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
        }

        List<Passenger> IPassengerRepository.GetAllPassengers() 
        {
            return passengers;
        }



    }
}