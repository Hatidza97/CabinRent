using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.ViewModel
{
    public class frmOcjeneKomentari
    {
        public int OcjenaId { get; set; }
        public int Ocjena1 { get; set; }
        public string Komentar { get; set; }
        public int ObjekatId { get; set; }
        public string NazivObjekta { get; set; }
        public int KlijentId { get; set; }
        public string ImeKlijenta { get; set; }
        public string PrezimeKlijenta { get; set; }
    }
}
