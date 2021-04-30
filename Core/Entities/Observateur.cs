using System;

namespace Core.Entities
{
    public class Observateur
    {
        public int ObservateurId { get; set; }
        public string NomPrenomObservateur { get; set; }
        public Station Station { get; set; }
    }
}