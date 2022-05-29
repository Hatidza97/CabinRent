using AutoMapper;
using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
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
            CreateMap<Database.Klijent, KlijentSearchRequest>().ReverseMap();
            CreateMap<Database.Klijent, KlijentUpdateRequest>().ReverseMap();
            CreateMap<Database.Klijent, KlijentInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, KorisniciInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnik, KorisniciUpdateRequest>().ReverseMap();
            CreateMap<Database.Korisnik, KorisniciSearchRequest>().ReverseMap();
            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<Database.Grad, GradSearchRequest>().ReverseMap();
            CreateMap<Database.Drzava, Model.Drzava>();
            CreateMap<Database.DetaljiRezervacije, Model.DetaljiRezervacije>();
            CreateMap<Database.DetaljiRezervacije, DetaljiRezervacijeUpdateRequest>().ReverseMap();
            CreateMap<Database.KorisnikUloge, Model.KorisnikUloge>();
            CreateMap<Database.Objekat, Model.Objekat>();
            CreateMap<Database.Objekat, ObjekatInsertRequest>().ReverseMap();
            CreateMap<Database.Objekat, ObjekatSearchRequest>().ReverseMap();
            CreateMap<Database.Objekat, ObjekatUpdateRequest>().ReverseMap();
            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<Database.Rezervacija, Model.Rezervacija>();
            CreateMap<Database.Rezervacija, RezervacijaSearchRequest>().ReverseMap();
            CreateMap<Database.Rezervacija, RezervacijaInsertRequest>().ReverseMap();
            CreateMap<Database.Rezervacija, RezervacijaUpdateRequest>().ReverseMap();
            CreateMap<Database.TipObjektaSllike, Model.TipObjektaSllike>();
            CreateMap<Database.TipObjektaSllike, ObjekatSlikeSearchRequest>().ReverseMap();
            CreateMap<Database.TipObjektaSllike, TipObjektaSllikeInsertRequest>().ReverseMap();
            CreateMap<Database.TipObjektum, Model.TipObjektum>();
            CreateMap<Database.TipObjektum, TipObjektumSearchRequest>().ReverseMap();
            CreateMap<Database.Uloga, Model.Uloga>();
            CreateMap<Database.Uloga, UlogaSearchRequest>().ReverseMap();
            CreateMap<Database.Uloga, UlogaUpdateRequest>().ReverseMap();
        }
    }
}
