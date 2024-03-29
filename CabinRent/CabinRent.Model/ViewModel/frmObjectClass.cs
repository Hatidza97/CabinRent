﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabinRent.Model.ViewModel
{
    public class frmObjectClass
    {
        public int ObjekatId { get; set; }
        public string Naziv { get; set; }
        public string Povrsina { get; set; }
        public int BrojMjestaDjeca { get; set; }
        public int BrojMjestaOdrasli { get; set; }
        public int BrojMjestaUkupno { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int TipObjektaId { get; set; }
        public int GradId { get; set; }
        public int KorisnikId { get; set; }
        public bool? Rezervisan { get; set; }
    }
}
