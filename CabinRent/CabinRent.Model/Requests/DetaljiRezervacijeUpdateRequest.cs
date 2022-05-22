using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabinRent.Model.Requests
{
    public class DetaljiRezervacijeUpdateRequest
    {
        //public int DetaljiRezervacijeId { get; set; }
        public int RezervacijaId { get; set; }
        public int? BrojSoba { get; set; }
        public string TipSobe { get; set; }
    }
}
