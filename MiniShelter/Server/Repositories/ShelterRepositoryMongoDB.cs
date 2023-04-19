using MiniShelter.Shared;
using MiniShelter.Server.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MiniShelter.Server.Repositories
{
    public class ShelterRepositoryMongoDB : IShelter
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Shelter> _shelterTable = null;

        // Connection til MongoDB database
        public ShelterRepositoryMongoDB()
        {
            _mongoClient = new MongoClient("mongodb+srv://kasper:123nohr@shelters.6i54ebh.mongodb.net/?retryWrites=true&w=majority"); //username & password bør gemmes i fremtidig version
            _database = _mongoClient.GetDatabase("shelterlife");
            _shelterTable = _database.GetCollection<Shelter>("shelters");
        }

        // Sletter et shelter vha et bestemt ID
        public string Delete(string shelterId)
        {
            var result = _shelterTable.DeleteOne(x => x.Id == shelterId);

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

        // Finder et shelter vha et ID på shelteret
        public Shelter GetShelter(string shelterId)
        {
            return _shelterTable.Find(x => x.Id == shelterId).FirstOrDefault();
        }

        // Trækker alle shelters ud af databasen, bruger ikke et filter 
        public List<Shelter> GetShelters()
        {
            return _shelterTable.Find(FilterDefinition<Shelter>.Empty).ToList(); // Henter alle shelters fra MongoDB uden noget filter
        }
    }
}
