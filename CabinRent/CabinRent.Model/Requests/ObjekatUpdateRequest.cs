using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class ObjekatUpdateRequest
    {
        // public int ObjekatId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Povrsina { get; set; }
        public int BrojMjestaDjeca { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int BrojMjestaOdrasli { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int BrojMjestaUkupno { get; set; }
        public string Opis { get; set; }
        [Required]
        public double Cijena { get; set; }
        public int GradId { get; set; }
        public int TipObjektaId { get; set; }

    }
}
