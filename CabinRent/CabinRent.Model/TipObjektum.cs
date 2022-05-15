using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model
{
    public partial class TipObjektum
    {
        public int TipObjektaId { get; set; }
        public string Tip { get; set; }

        //public virtual ICollection<Objekat> Objekats { get; set; }
    }
}
