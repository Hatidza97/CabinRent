using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Objekat
    {
        public Objekat()
        {
            Ocjenas = new HashSet<Ocjena>();
            Rezervacijas = new HashSet<Rezervacija>();
            TipObjektaSllikes = new HashSet<TipObjektaSllike>();
        }

        public int ObjekatId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Povrsina { get; set; } = null!;
        public int BrojMjestaDjeca { get; set; }
        public int BrojMjestaOdrasli { get; set; }
        public int BrojMjestaUkupno { get; set; }
        public string Opis { get; set; } = null!;
        public double Cijena { get; set; }
        public int TipObjektaId { get; set; }
        public int GradId { get; set; }
        public int KorisnikId { get; set; }
        public bool? Rezervisan { get; set; }

        public virtual Grad Grad { get; set; } = null!;
        public virtual Korisnik Korisnik { get; set; } = null!;
        public virtual TipObjektum TipObjekta { get; set; } = null!;
        public virtual ICollection<Ocjena> Ocjenas { get; set; }
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
        public virtual ICollection<TipObjektaSllike> TipObjektaSllikes { get; set; }
    }
}
