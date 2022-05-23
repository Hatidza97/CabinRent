using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services.Database;

namespace CabinRent.Services
{
    public class ObjekatService : IObjekatService
    {
        protected readonly IMapper _mapper;
        public eRentContext _context;
        public ObjekatService(eRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public List<Model.Objekat> Get()
        //{
        //    return _context.Objekats.ToList().Select(x => _mapper.Map<Model.Objekat>(x)).ToList();
        //}

        public Model.Objekat GetByID(int id)
        {
            var entity = _context.Objekats.Find(id);
            return _mapper.Map<Model.Objekat>(entity);
        }
        public bool Delete(int id)
        {
            var entity = _context.Objekats.Find(id);
            if (entity != null)
            {
                _context.Objekats.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Model.Objekat> Get(ObjekatSearchRequest request)
        {
            var query = _context.Objekats
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.Naziv));
            }
            //if (!string.IsNullOrWhiteSpace(request.Cijena.ToString()))
            //{
            //    query = query.Where(x => x.Povrsina.StartsWith(request.Cijena.ToString()));
            //}

            var list = query.ToList();
            return _mapper.Map<List<Model.Objekat>>(list);
        }
        public Model.Objekat Update(int id, ObjekatUpdateRequest request)
        {
            var entity = _context.Objekats.Find(id);

            _context.Objekats.Attach(entity);
            _context.Objekats.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Objekat>(entity);
        }
        //public Model.Objekat SearchTip(ObjekatTipSearchRequest request)
        //{
        //    var entity = _mapper.Map<Database.Objekat>(request);
        //    entity.TipObjektaId = request.TipObjektaId;
        //    entity.TipObjekta.Tip = request.Tip;
        //    return _mapper.Map<Model.Objekat>(entity);
        //}
        public Model.Objekat Insert(ObjekatInsertRequest request)
        {
            var entity = _mapper.Map<Database.Objekat>(request);
            entity.Naziv = request.Naziv;
            entity.Povrsina = request.Povrsina;
            entity.BrojMjestaDjeca = request.BrojMjestaDjeca;
            entity.BrojMjestaOdrasli = request.BrojMjestaOdrasli;
            entity.BrojMjestaUkupno = request.BrojMjestaUkupno;
            entity.Cijena = request.Cijena;
            entity.Opis = request.Opis;
            entity.Rezervisan = request.Rezervisan;
            entity.KorisnikId = request.KorisnikId;
            entity.TipObjektaId = request.TipObjektaId;
            entity.GradId = request.GradId;
            _context.Objekats.Add(entity);

            _context.SaveChanges();
            return _mapper.Map<Model.Objekat>(entity);
        }

    }
}
