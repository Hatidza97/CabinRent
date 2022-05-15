using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Klijent
    {
        public Klijent()
        {
            Ocjenas = new HashSet<Ocjena>();
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public int KlijentId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string? LozinkaHash { get; set; }
        public string? LozinkaSalt { get; set; }
        public byte[]? Slika { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; } = null!;
        public virtual ICollection<Ocjena> Ocjenas { get; set; }
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
