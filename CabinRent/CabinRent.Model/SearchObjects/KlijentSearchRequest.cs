using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.SearchObjects
{
    public class KlijentSearchRequest
    {
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public byte?[] Slika { get; set; }
        public int GradId { get; set; }

    }
}
