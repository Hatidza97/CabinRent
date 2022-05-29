using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class TipObjektaSllikeInsertRequest
    {
        public int ObjekatId { get; set; }
        public byte[] Slika { get; set; }
    }
}
