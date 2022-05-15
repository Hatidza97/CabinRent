using System;
using System.Collections.Generic;

namespace CabinRent.Services.Database
{
    public partial class TipObjektaSllike
    {
        public int TipObjektaSlikeId { get; set; }
        public byte[]? ImageData { get; set; }
        public int ObjekatId { get; set; }

        public virtual Objekat Objekat { get; set; } = null!;
    }
}
