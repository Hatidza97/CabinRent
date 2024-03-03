using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class KorisnikUloge
    {
        public int KorisnikUlogeId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }

        //public virtual Korisnik Korisnik { get; set; }
        public virtual Uloga Uloga { get; set; }
    }
}
