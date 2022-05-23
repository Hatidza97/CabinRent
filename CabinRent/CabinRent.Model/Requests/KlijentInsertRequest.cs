using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class KlijentInsertRequest
    {
        //public int KlijentId { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefon { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }
        public int? GradId { get; set; }
        public string Lozinka { get; set; }
        //public string LozinkaHash { get; set; }
        //public string LozinkaSalt { get; set; }
    }
}
