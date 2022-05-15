using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            KorisnikUloges = new HashSet<KorisnikUloge>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string OpisUloge { get; set; } = null!;

        public virtual ICollection<KorisnikUloge> KorisnikUloges { get; set; }
    }
}
