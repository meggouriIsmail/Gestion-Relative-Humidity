using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Gestion_Relative_Humidity.ViewModel
{
    public class HumidityModel
    {
        public float Sec { get; set; }
        public float Mou { get; set; }
        public float Hum { get; set; }
        public float ThermometreMin { get; set; }
        public float ThermometreMax { get; set; }
        public float ThermometreMoyMaxMin { get; set; }
        public float ThermometreMA { get; set; }
        public float ThermometreMI { get; set; }
        public int Heur { get; set; }
        public DateTime DateObservation { get; set; }
        public int StationId { get; set; }
        public int ObservateurId { get; set; }
        public List<Station> Stations { get; set; }
        public List<Observateur> Observateurs { get; set; }
    }
}
