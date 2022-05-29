using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.SearchObjects
{
    public class ObjekatSlikeSearchRequest
    {
        public int? TipObjektaSlikeId { get; set; }
        public int? ObjekatId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
