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
    [ApiController] // Indikerer, at denne klasse er en Web API-controller.
    [Route("api/Shelter")] // Angiver URL-ruten for denne controller.
    public class ShelterController : ControllerBase // ShelterController nedarver fra ControllerBase og er en controller for api/Shelter.
    {

        private static List<Shelter> mShelters = new List<Shelter>(); // En statisk liste over Shelter-objekter.

        private IShelter myRepo; // En referance til vores data repository

        public ShelterController(IShelter myRepo) // Konstruktør til at initialisere myRepo
        {

            this.myRepo = myRepo;
        }

        [HttpGet] // Angiver, at denne metode skal køre, når en HTTP GET-anmodning modtages.
        public IEnumerable<Shelter> GetShelters() // Henter en liste over Shelter-objekter fra vores repository.
        {
            Console.WriteLine("get ");
            return myRepo.GetShelters();
        }

        [HttpDelete] // Angiver, at denne metode skal køre, når en HTTP DELETE-anmodning modtages.
        [Route("{Id}")] // Angiver, at denne metode skal matche en rute med en enkelt parametre "Id"
        public void Delete(string Id) // Sletter et Shelter-objekt fra vores repository.
        {
            Console.WriteLine("Deleted");
            myRepo.Delete(Id);
        }

        [HttpGet] // Angiver, at denne metode skal køre, når en HTTP GET-anmodning modtages.
        [Route("GetShelter/{shelterId}")] // Angiver, at denne metode skal matche en rute med en enkelt parametre "shelterId"
        public Shelter GetShelter(string shelterId) // Henter et enkelt Shelter-objekt fra vores repository baseret på den angivne shelterId.
        {
            Console.WriteLine("Shelter found OK");
            return myRepo.GetShelter(shelterId);
        }
    }
}