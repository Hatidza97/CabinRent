using AutoMapper;
using CabinRent.Model.SearchObjects;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class GradService : IGradService
    {
        protected readonly IMapper _mapper;
        public eRentContext _context { get; set; }

   
        public GradService(eRentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Model.Grad GetById(int id)
        {
            var entity = _context.Grads.Find(id);
            return _mapper.Map<Model.Grad>(entity);
        }
        public List<Model.Grad> Get(GradSearchRequest search)
        {
            var query = _context.Grads.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.NazivGrada))
            {
                query = query.Where(x => x.Naziv.Contains(search.NazivGrada));
            }
            if (search.GradId.HasValue)
            {
                query = query.Where(x => x.GradId == search.GradId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Grad>>(list);

        }

    }
}
