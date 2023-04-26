using MiniShelter.Shared;
using static System.Net.WebRequestMethods;

namespace MiniShelter.Client.Services
{
    public interface IShelterService
    {
        Task<IEnumerable<Shelter>> GetShelters();
        // Ole mener vi skal bruge dette (Se modul fra 26/04)
    }
}
