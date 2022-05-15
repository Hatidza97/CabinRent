using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class Uloga
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string OpisUloge { get; set; } 

        //public virtual ICollection<KorisnikUloge> KorisnikUloges { get; set; }
    }
}
