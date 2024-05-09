using AirportTicketBookingSystem.Controller;
using AirportTicketBookingSystem.Controllers;
using AirportTicketBookingSystem.Utilities;

namespace AirportTicketBookingSystem

{
    class Program
    {
        static void Main(string[] args)
        {

            PassengerController pc = PassengerController.GetInstance();
            BookingController bc = BookingController.GetInstance();

            Menu menu = new Menu(pc, bc);
            menu.StartMenu();



        }
    }
}


