using MiniShelter.Shared;
namespace MiniShelter.Server.Interfaces
{
    public interface IBooking
    {

        Booking GetBooking(string bookingID); // Hent specifikt shelter ud fra ID

        List<Booking> GetBookings(); // Hent alle shelter

        string Delete(string bookingID); // Slet shelter baseret på ID

        void AddBooking(Booking booking); // Tilføjer en booking

    }
}
