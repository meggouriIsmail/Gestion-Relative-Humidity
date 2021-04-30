using System;

namespace Core.Entities
{
    public class Station
    {
        public int StationId { get; set; }
        public string NomStation { get; set; }
        public Bassin Bassin { get; set; }
    }
}