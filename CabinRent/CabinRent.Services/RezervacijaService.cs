using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class RezervacijaService : IRezervacijaService
    {
        protected readonly IMapper _mapper;
        public eRentContext context { get; set; }
        public RezervacijaService(eRentContext Context, IMapper mapper)
        {
            context = Context;
            _mapper = mapper;
        }

        public Model.Rezervacija GetById(int id)
        {
            var entity = context.Rezervacijas.Find(id);
            return _mapper.Map<Model.Rezervacija>(entity);
        }
        public bool Delete(int id)
        {
            var entity = context.Rezervacijas.Find(id);
            if (entity != null)
            {
                context.Rezervacijas.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //public List<Model.Rezervacija> Get(RezervacijaSearchRequest request)
        //{
        //    var query = context.Rezervacijas.Include(x => x.DetaljiRezervacijes)
        //        .AsQueryable();
        //    //if (!string.IsNullOrWhiteSpace(request.Otkazano.ToString()))
        //    //{
        //    //    query = query.Where(x => x.Otkazano!=0);
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(request.Prezime))
        //    //{
        //    //    query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(request.Telefon))
        //    //{
        //    //    query = query.Where(x => x.Telefon.Contains(request.Telefon));
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(request.Username))
        //    //{
        //    //    query = query.Where(x => x.KorisnickoIme == request.Username);
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(request.Email))
        //    //{
        //    //    query = query.Where(x => x.Email.StartsWith(request.Email));
        //    //}

        //    var list = query.ToList();
        //    return _mapper.Map<List<Model.Rezervacija>>(list);
        //}
        //public Model.Rezervacija Insert(RezervacijaInsertRequest request)
        //{
        //    var entity = _mapper.Map<Database.Rezervacija>(request);
        //    entity.Datum = request.Datum;
        //    entity.DatumPrijave = request.DatumPrijave;
        //    entity.DatumOdjave = request.DatumOdjave;
        //    entity.BrojDjece = request.BrojDjece;
        //    entity.BrojOdraslih = request.BrojOdraslih;
        //    entity.Otkazano = request.Otkazano;
        //    context.Rezervacijas.Add(entity);

        //    context.SaveChanges();
        //    return _mapper.Map<Model.Rezervacija>(entity);
        //}
        //public Model.Rezervacija Update(int id, RezervacijaUpdateRequest request)
        //{
        //    var entity = context.Rezervacijas.Find(id);

        //    context.Rezervacijas.Attach(entity);
        //    context.Rezervacijas.Update(entity);

        //    _mapper.Map(request, entity);
        //    context.SaveChanges();

        //    return _mapper.Map<Model.Rezervacija>(entity);
        //}
    }
}
