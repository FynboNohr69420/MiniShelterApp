using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MiniShelter.Shared
{
    public class Shelter
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";
        [BsonElement("navn")]
        public string Navn { get; set; } = "";
        [BsonElement("kommunekode")]
        public int Kommunekode { get; set; } = 0;
        [BsonElement("antal_pl")]
        public int Antal_pl { get; set; } = 0;
        [BsonElement("oprettet")]
        public string? Oprettet { get; set; } = "";
        [BsonElement("cvr_navn")]
        public string? Cvr_navn { get; set; } = "";
        [BsonElement("facil_ty")]
        public string? Facil_ty { get; set; } = "";
        [BsonElement("beskrivels")]
        public string? Beskrivels { get; set; } = "";
        [BsonElement("lang_beskr")]
        public string? Lang_beskr { get; set; } = "";
        [BsonElement("handicap")]
        public string? Handicap { get; set; } = "";
        [BsonElement("postnr")]
        public string? Postnr { get; set; } = "";
        [BsonElement("latitude")]
        public double? Latitude { get; set; } = 0;
        [BsonElement("longtitude")]
        public double? Longtitude { get; set; } = 0;


    }
}
