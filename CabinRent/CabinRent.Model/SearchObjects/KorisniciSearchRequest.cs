using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.SearchObjects
{
    public class KorisniciSearchRequest
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
