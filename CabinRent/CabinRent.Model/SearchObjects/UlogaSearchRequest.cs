using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.SearchObjects
{
    public class UlogaSearchRequest
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string OpisUloge { get; set; }
    }
}
