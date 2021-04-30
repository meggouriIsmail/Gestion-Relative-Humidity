using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Gestion_Relative_Humidity.ViewModel
{
    public class BassinModel
    {
        public string NomBassin { get; set; }
        List<Station> Stations { get; }
    }
}
