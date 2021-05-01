using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Gestion_Relative_Humidity.ViewModel
{
    public class HumidityModel
    {
        [Required]
        public float Sec { get; set; }
        [Required]
        public float Mou { get; set; }
        [Required]
        public float Hum { get; set; }
        public float ThermometreMin { get; set; }
        public float ThermometreMax { get; set; }
        public float ThermometreMoyMaxMin { get; set; }
        public float ThermometreMA { get; set; }
        public float ThermometreMI { get; set; }
        [Required]
        public int Heur { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateObservation { get; set; }
        [Required]
        public int StationId { get; set; }
        [Required]
        public int ObservateurId { get; set; }
        public Station Stations { get; set; }
        public List<Observateur> Observateurs { get; set; }
    }
}
