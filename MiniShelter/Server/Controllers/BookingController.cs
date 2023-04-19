using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShelter.Shared;
using MiniShelter.Server.Repositories;
using MiniShelter.Server.Interfaces;


namespace MiniShelter.Server.Controllers
{
    // Angiver at klassen er en API-controller
    [ApiController]
    // Angiver baseruten for controllerens handlinger
    [Route("api/Booking")]
    public class BookingController : ControllerBase
    {
        // En tom liste til senere brug
        private static List<Shelter> mShelters = new List<Shelter>()
        {
            // Der er ingen shelters i listen, så den er tom
        };

        // En reference til databasen gennem vores repository interface
        private IBooking myRepo;

        // Konstruktør for controlleren, der tager imod en IBooking instans
        public BookingController(IBooking myRepo)
        {
            // Gemmer referencen til databasen i dette objekt
            this.myRepo = myRepo;
        }

        // En metode, der håndterer HTTP GET requests til /api/Booking
        [HttpGet]
        public IEnumerable<Booking> GetBookings()
        {
            // Skriver en besked til konsollen
            Console.WriteLine("get ");
            // Returnerer alle bookings i databasen gennem vores repository
            return myRepo.GetBookings();
        }

        // En metode, der håndterer HTTP POST requests til /api/Booking
        [HttpPost]
        public void AddBooking(Booking booking)
        {
            // Skriver en besked til konsollen med bookingens ID
            Console.WriteLine("post " + booking.Id);
            // Tilføjer bookingen til databasen gennem vores repository
            myRepo.AddBooking(booking);
        }

        // En metode, der håndterer HTTP DELETE requests til /api/Booking/{Id}
        [HttpDelete]
        [Route("{Id}")]
        public void Delete(string Id)
        {
            // Skriver en besked til konsollen om at bookingen er blevet slettet
            Console.WriteLine("Deleted");
            // Sletter bookingen fra databasen gennem vores repository
            myRepo.Delete(Id);
        }

    
    }
}

