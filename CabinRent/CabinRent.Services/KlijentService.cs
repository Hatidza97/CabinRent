using AutoMapper;
using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class KlijentService : IKlijentService
    {
        protected readonly IMapper _mapper;
        public eRentContext context { get; set; }
        public KlijentService(eRentContext Context, IMapper mapper)
        {
            context = Context;
            _mapper = mapper;
        }
        public Model.Klijent GetById(int id)
        {
            var entity = context.Klijents.Find(id);
            return _mapper.Map<Model.Klijent>(entity);
        }
        public bool Delete(int id)
        {
            var entity = context.Klijents.Find(id);
            if (entity != null)
            {
                context.Klijents.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Model.Klijent> Get(KlijentSearchRequest request)
        {
            var query = context.Klijents

                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request.Telefon))
            {
                query = query.Where(x => x.Telefon.Contains(request.Telefon));
            }
            if (!string.IsNullOrWhiteSpace(request.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == request.KorisnickoIme);
            }
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(x => x.Email.StartsWith(request.Email));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Klijent>>(list);
        }
        public Model.Klijent Update(int id, KlijentUpdateRequest request)
        {
            var entity = context.Klijents.Find(id);

            context.Klijents.Attach(entity);
            context.Klijents.Update(entity);

            _mapper.Map(request, entity);
            context.SaveChanges();

            return _mapper.Map<Model.Klijent>(entity);
        }
        public Model.Klijent Insert(KlijentInsertRequest request)
        {
            var entity = _mapper.Map<Database.Klijent>(request);
            entity.Ime = request.Ime;
            entity.Email = request.Email;
            entity.KorisnickoIme = request.KorisnickoIme;
            entity.Email = request.Email;
            entity.GradId = (int)request.GradId;
            var grad = context.Grads.Find(request.GradId);
            //entity.Grad.Naziv = grad.Naziv;
            entity.Telefon = request.Telefon;
            context.Klijents.Add(entity);

            context.SaveChanges();
            return _mapper.Map<Model.Klijent>(entity);
        }
    }
}
