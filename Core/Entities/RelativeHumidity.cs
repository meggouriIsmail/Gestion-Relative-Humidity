using System;

namespace Core.Entities
{
    public class RelativeHumidity
    {
        public int RelativeHumidityId { get; set; }
        public float Sec { get; set; }
        public float Mou { get; set; }
        public float Hum { get; set; }
        public float ThermometreMin { get; set; }
        public float ThermometreMax { get; set; }
        public float ThermometreMoyMaxMin { get; set; }
        public float ThermometreMA { get; set; }
        public float ThermometreMI { get; set; }
        public int Heur { get; set; }
        public DateTime  DateObservation { get; set; }
        public Station Stations { get; set; }
        public int StationId { get; set; }
        public Observateur Observateurs { get; set; }
        public int ObservateurId { get; set; }
    }
}