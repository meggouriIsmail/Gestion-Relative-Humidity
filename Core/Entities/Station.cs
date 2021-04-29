using System;

namespace Gestion_RH.Models
{
    public class Station
    {
        public Guid StationId { get; set; }
        public string NomStation { get; set; }
        public Bassin Bassin { get; set; }
    }
}