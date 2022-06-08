using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabinRent.Model
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; } 
        public string Email { get; set; }
        public string Telefon { get; set; } 
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }

        public virtual ICollection<KorisnikUloge> KorisnikUloges { get; set; }
        public string RoleNames => string.Join(", ", KorisnikUloges?.Select(x => x.Uloga?.Naziv)?.ToList());

        //public virtual ICollection<Objekat> Objekats { get; set; }
    }
}
