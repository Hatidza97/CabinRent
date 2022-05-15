using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class Klijent
    {
       
        public int KlijentId { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; }
        public string Email { get; set; } 
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
       
        public byte[] Slika { get; set; }
        public int GradId { get; set; }

        //public virtual Grad Grad { get; set; } 
        //public virtual ICollection<Ocjena> Ocjenas { get; set; }
        //public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
