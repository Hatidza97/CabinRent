using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KorisnikUloges = new HashSet<KorisnikUloge>();
            Objekats = new HashSet<Objekat>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public byte[]? Slika { get; set; }

        public virtual ICollection<KorisnikUloge> KorisnikUloges { get; set; }
        public virtual ICollection<Objekat> Objekats { get; set; }
    }
}
