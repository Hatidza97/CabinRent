using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class KorisnikUloge
    {
        public int KorisnikUlogeId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }

        public virtual Korisnik Korisnik { get; set; } = null!;
        public virtual Uloga Uloga { get; set; } = null!;
    }
}
