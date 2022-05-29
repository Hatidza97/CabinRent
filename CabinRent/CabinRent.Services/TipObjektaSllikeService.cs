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
    public class TipObjektaSllikeService:ITipObjektaSLlikeService
    {
        protected readonly IMapper _mapper;
        public eRentContext _context;
        public TipObjektaSllikeService(eRentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Model.TipObjektaSllike GetByID(int id)
        {
            var entity = _context.TipObjektaSllikes.Find(id);
            return _mapper.Map<Model.TipObjektaSllike>(entity);
        }
        public List<Model.TipObjektaSllike> Get(ObjekatSlikeSearchRequest request)
        {
            var query = _context.TipObjektaSllikes
                .Include(x => x.Objekat)
                .AsQueryable();
             
            if (request.ObjekatId.HasValue)
            {
                query = query.Where(x => x.ObjekatId == request.ObjekatId);
            }
           if(request.ImageData != null)
            {
                query = query.Where(x => x.ImageData.Any());
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.TipObjektaSllike>>(list);
        }
        public Model.TipObjektaSllike Insert(TipObjektaSllikeInsertRequest request)
        {
            var entity = _mapper.Map<Database.TipObjektaSllike>(request);
            entity.ObjekatId = request.ObjekatId;
            entity.ImageData = request.Slika;
            _context.TipObjektaSllikes.Add(entity);

            _context.SaveChanges();
            return _mapper.Map<Model.TipObjektaSllike>(entity);
        }
    }
}
