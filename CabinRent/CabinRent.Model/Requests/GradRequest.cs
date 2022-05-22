using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class GradRequest
    {
        public int GradId { get; set; }
        public string NazivGrada { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
