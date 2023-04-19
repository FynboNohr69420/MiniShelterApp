using MiniShelter.Shared;
using MiniShelter.Server.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MiniShelter.Server.Repositories
{
    public class BookingRepositoryMongoDB : IBooking
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Booking> _bookingTable = null;
        public BookingRepositoryMongoDB()
        {
            _mongoClient = new MongoClient("mongodb+srv://kasper:123nohr@shelters.6i54ebh.mongodb.net/?retryWrites=true&w=majority");
            _database = _mongoClient.GetDatabase("shelterlife");
            _bookingTable = _database.GetCollection<Booking>("bookinger");
        }

        // Sletter et booking vha et bookingiD
        public string Delete(string bookingId)
        {
            var result = _bookingTable.DeleteOne(x => x.Id == bookingId);

            // Hvis den findet et shelter med et matchende ID, så sletter den det, og retunere "Deleted"
            // Hvis der ikke er et shelter med det givne ID, returneres der "Not Found"
            if (result.DeletedCount > 0)
            {
                return "Deleted";
            }
            else
            {
                return "Not Found";
            }
        }

        // Findet en bestemt booking vha et bookingId
        public Booking GetBooking(string bookingId)
        {
            return _bookingTable.Find(x => x.Id == bookingId).FirstOrDefault();
        }

        public List<Booking> GetBookings()
        {
            return _bookingTable.Find(FilterDefinition<Booking>.Empty).ToList(); // Henter alle shelters fra MongoDB uden noget filter
        }

        public void SaveOrUpdate(Booking booking)
        {
            // Find det eksisterende Shelter objekt i samlingen baseret på dets Id
            var bookingObj = _bookingTable.Find(x => x.Id == booking.Id).FirstOrDefault();

            // Tjek om det retrievede Shelter objekt er null, hvilket indikerer at det ikke findes i samlingen
            if (bookingObj == null)
            {
                // Hvis Shelter objektet ikke findes, indsættes et nyt dokument i samlingen
                _bookingTable.InsertOne(booking);
            }
            else
            {
                // Hvis Shelter objektet findes, erstattes det eksisterende dokument i samlingen med det opdaterede Shelter objekt
                _bookingTable.ReplaceOne(x => x.Id == booking.Id, booking);
            }
        }

        // Tilføjer en booking
        public void AddBooking(Booking booking)
        {
            _bookingTable.InsertOne(booking);
        }

        // Opdaterer en booking vha et bookingId, den søger gennem databasen og matcher id'et til en booking
        public void UpdateBooking(Booking booking)
        {
            _bookingTable.ReplaceOne(i => i.Id == booking.Id, booking);
        }
    }
}
