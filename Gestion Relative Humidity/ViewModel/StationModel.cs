using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Gestion_Relative_Humidity.ViewModel
{
    public class StationModel
    {
        public string NomStation { get; set; }
        List<Observateur> Observateurs { get; }
    }
}
