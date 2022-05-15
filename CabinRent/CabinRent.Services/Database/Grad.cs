using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Klijents = new HashSet<Klijent>();
            Objekats = new HashSet<Objekat>();
        }

        public int GradId { get; set; }
        public string? Naziv { get; set; }
        public string? PostBroj { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; } = null!;
        public virtual ICollection<Klijent> Klijents { get; set; }
        public virtual ICollection<Objekat> Objekats { get; set; }
    }
}
