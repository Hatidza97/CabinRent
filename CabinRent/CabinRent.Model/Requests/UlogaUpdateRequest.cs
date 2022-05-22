using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class UlogaUpdateRequest
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string OpisUloge { get; set; }
    }
}
