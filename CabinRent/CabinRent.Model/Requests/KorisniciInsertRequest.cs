using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class KorisniciInsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public byte[] Slika { get; set; }
    }
}
