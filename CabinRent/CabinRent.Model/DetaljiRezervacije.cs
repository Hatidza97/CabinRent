using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class DetaljiRezervacije
    {
        public int DetaljiRezervacijeId { get; set; }
        public int RezervacijaId { get; set; }
        public int? BrojSoba { get; set; }
        public string TipSobe { get; set; }

        //public virtual Rezervacija Rezervacija { get; set; } = null!;
    }
}
