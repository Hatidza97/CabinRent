using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Klijent, Model.Klijent>();
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<Database.Drzava, Model.Drzava>();
            CreateMap<Database.DetaljiRezervacije, Model.DetaljiRezervacije>();
            CreateMap<Database.KorisnikUloge, Model.KorisnikUloge>();
            CreateMap<Database.Objekat, Model.Objekat>();
            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<Database.Rezervacija, Model.Rezervacija>();
            CreateMap<Database.TipObjektaSllike, Model.TipObjektaSllike>();
            CreateMap<Database.TipObjektum, Model.TipObjektum>();
            CreateMap<Database.Uloga, Model.Uloga>();
        }
    }
}
