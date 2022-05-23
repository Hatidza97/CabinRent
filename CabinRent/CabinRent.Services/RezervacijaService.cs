using AutoMapper;
using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services.Database;
using Microsoft.EntityFrameworkCore;
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
        public List<Model.Rezervacija> Get(RezervacijaSearchRequest request)
        {
            var query = context.Rezervacijas.Include(x => x.DetaljiRezervacijes)
                .Include(x=>x.Klijent)
                .Include(x=>x.Objekat)
                .AsQueryable();
            //if (!string.IsNullOrWhiteSpace(request.Otkazano.ToString()))
            //{
            //    query = query.Where(x => x.Otkazano != false);
            //}
            

            var list = query.ToList();
            return _mapper.Map<List<Model.Rezervacija>>(list);
        }
        public Model.Rezervacija Insert(RezervacijaInsertRequest request)
        {
            var entity = _mapper.Map<Database.Rezervacija>(request);
            entity.DatumPrijave = request.DatumPrijave;
            entity.DatumOdjave = request.DatumOdjave;
            entity.BrojDjece = request.BrojDjece;
            entity.BrojOdraslih = request.BrojOdraslih;
            entity.Otkazano = request.Otkazano;
            entity.KlijentId = request.KlijentId;
            entity.ObjekatId= request.ObjekatId;
            context.Rezervacijas.Add(entity);

            context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);
        }
        public Model.Rezervacija Update(int id, RezervacijaUpdateRequest request)
        {
            var entity = context.Rezervacijas.Find(id);

            context.Rezervacijas.Attach(entity);
            context.Rezervacijas.Update(entity);

            _mapper.Map(request, entity);
            context.SaveChanges();

            return _mapper.Map<Model.Rezervacija>(entity);
        }
    }
}
