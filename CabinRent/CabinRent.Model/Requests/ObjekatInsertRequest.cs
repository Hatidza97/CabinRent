using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class ObjekatInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Povrsina { get; set; }
        [Required]
        public int BrojMjestaDjeca { get; set; }
        [Required]
        public int BrojMjestaOdrasli { get; set; }
        [Required]
        public int BrojMjestaUkupno { get; set; }
        public string Opis { get; set; }
        [Required]
        //[MinLength(2)]
        public double Cijena { get; set; }

    }
}
