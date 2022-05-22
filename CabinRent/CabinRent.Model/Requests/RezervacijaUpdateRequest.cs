using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class RezervacijaUpdateRequest
    {
        public int Id { get; set; }
        public int Otkazano { get; set; }
    }
}
