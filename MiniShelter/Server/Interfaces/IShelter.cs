using MiniShelter.Shared;
namespace MiniShelter.Server.Interfaces
{
    public interface IShelter
    {

        Shelter GetShelter(string shelterId); // Hent specifikt shelter ud fra ID

        List<Shelter> GetShelters(); // Hent alle shelter

        string Delete(string shelterId); // Slet shelter baseret på ID
    }
}
