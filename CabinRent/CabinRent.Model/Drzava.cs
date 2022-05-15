using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class Drzava
    {
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        //public virtual ICollection<Grad> Grads { get; set; }
    }
}
