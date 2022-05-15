using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class Ocjena
    {
        public int OcjenaId { get; set; }
        public int Ocjena1 { get; set; }
        public string Komentar { get; set; }
        public int ObjekatId { get; set; }
        public int KlijentId { get; set; }

        //public virtual Klijent Klijent { get; set; } 
        //public virtual Objekat Objekat { get; set; } 
    }
}
