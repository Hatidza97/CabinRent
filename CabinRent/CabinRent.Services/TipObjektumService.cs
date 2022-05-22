using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class TipObjektumService : ITipObjektumService
    {
        protected readonly IMapper _mapper;
        public eRentContext _context;
        public TipObjektumService(eRentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        //public List<Model.TipObjektum> Get()
        //{
        //    return _context.TipObjekta.ToList().Select(x => _mapper.Map<Model.TipObjektum>(x)).ToList();
        //}
        public Model.TipObjektum GetById(int id)
        {
            var entity = _context.TipObjekta.Find(id);
            return _mapper.Map<Model.TipObjektum>(entity);
        }
        //public List<Model.TipObjektum> Get(TipObjektumSearchRequest search)
        //{
        //    var query = _context.TipObjekta
        //        .AsQueryable();
        //    if (!string.IsNullOrWhiteSpace(search.Tip))
        //    {
        //        query = query.Where(x => x.Tip.StartsWith(search.Tip));
        //    }

        //    var list = query.ToList();
        //    return _mapper.Map<List<Model.TipObjektum>>(list);
        //}


    }
}
