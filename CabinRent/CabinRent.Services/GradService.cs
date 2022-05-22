using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
//   public class GradService : BaseService<Model.Grad, GradSearchRequest, CabinRent.Services.Database.Grad>
//    {
//        protected readonly IMapper _mapper;
//        public eRentContext _context;

//        //public List<Model.Grad> Get()
//        //{
//        //    return _context.Grads.ToList().Select(x => _mapper.Map<Model.Grad>(x)).ToList();
//        //}
//        public GradService(eRentContext context, IMapper mapper) : base(context, mapper)
//        {

//        }
//        //public Model.Grad GetById(int id)
//        //{
//        //    var entity = _context.Grads.Find(id);
//        //    return _mapper.Map<Model.Grad>(entity);
//        //}
//        public List<Model.Grad> Get(GradSearchRequest search = null)
//        {
//            var entity = _context.Set<Database.Grad>().AsQueryable();
//            if (!string.IsNullOrWhiteSpace(search?.NazivGrada))
//            {
//                entity = entity.Where(x => x.Naziv.Contains(search.NazivGrada));
//            }
//            if (search.GradId.HasValue)
//            {
//                entity = entity.Where(x => x.GradId == search.GradId);
//            }
//            var list = entity.ToList();
//            return _mapper.Map<List<Model.Grad>>(list);

//        }

//    }
}
