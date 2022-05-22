using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class RezervacijaInsertRequest
    {
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumOdjave { get; set; }
        public int BrojOdraslih { get; set; }
        public int BrojDjece { get; set; }
        public bool Otkazano { get; set; }
        public int KlijentId { get; set; }
        public int ObjekatId { get; set; }

        //public virtual Klijent Klijent { get; set; } = null!;
        //public virtual Objekat Objekat { get; set; } = null!;
        //public virtual ICollection<DetaljiRezervacije> DetaljiRezervacijes { get; set; }
    }
}
