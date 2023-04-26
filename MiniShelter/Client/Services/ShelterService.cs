using MiniShelter.Shared;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using MiniShelter.Client.Pages;

namespace MiniShelter.Client.Services
{
    public class ShelterService : IShelterService
    {
        HttpClient http;

        public ShelterService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Shelter>> GetShelters() // Henter en liste over Shelter-objekter fra vores repository.
        {
            Console.WriteLine("get ");
            var shelterlist = await http.GetFromJsonAsync<Shelter[]>("api/Shelter");
            return shelterlist;
        }

        //protected override async Task OnInitializedAsync() //Asynkron method da dette er nødvendigt for at kunne bruge 'await'
        //{
        //    shelterlist = await Http.GetFromJsonAsync<Shelter[]>("api/Shelter"); //Henter alle shelter fra collection'en gennem controlleren

        //}
    }
}
