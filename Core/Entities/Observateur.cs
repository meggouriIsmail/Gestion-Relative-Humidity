using System;

namespace Gestion_RH.Models
{
    public class Observateur
    {
        public Guid ObservateurId { get; set; }
        public string NomPrenomObservateur { get; set; }
        public Station Station { get; set; }
}
}