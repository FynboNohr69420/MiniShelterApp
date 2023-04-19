using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiniShelter.Shared
{
    public class Booking
    {
        public DateTime booking;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [Required]
        public string navn { get; set; } = "";

        public int telefonnummer { get; set; } = 0;

        [Required(ErrorMessage = "Email er påkrævet ved booking")]
        [EmailAddress(ErrorMessage = "Indtast venligst en gyldig email adresse.")]
        public string email { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string shelterID { get; set; } = "";

    }
}
