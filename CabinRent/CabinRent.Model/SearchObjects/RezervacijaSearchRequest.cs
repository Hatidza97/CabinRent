using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.SearchObjects
{
    public class RezervacijaSearchRequest
    {
        public int RezervacijaId { get; set; }
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumOdjave { get; set; }
        public int BrojOdraslih { get; set; }
        public int BrojDjece { get; set; }
        public bool? Otkazano { get; set; }
        public int KlijentId { get; set; }
        public int ObjekatId { get; set; }
    }
}
