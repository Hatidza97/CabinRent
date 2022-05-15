using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Ocjena
    {
        public int OcjenaId { get; set; }
        public int Ocjena1 { get; set; }
        public string? Komentar { get; set; }
        public int ObjekatId { get; set; }
        public int KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; } = null!;
        public virtual Objekat Objekat { get; set; } = null!;
    }
}
