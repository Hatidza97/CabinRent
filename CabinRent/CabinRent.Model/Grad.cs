using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class Grad
    {
       
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string PostBroj { get; set; }
        public int DrzavaId { get; set; }

        //public virtual Drzava Drzava { get; set; } = null!;
        //public virtual ICollection<Klijent> Klijents { get; set; }
        //public virtual ICollection<Objekat> Objekats { get; set; }
    }
}
