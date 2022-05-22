using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class OcjenaService : IOcjenaService
    {
        protected readonly IMapper _mapper;
        public eRentContext _context;
        public OcjenaService(eRentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<Model.Ocjena> Get()
        {
            return _context.Ocjenas.ToList().Select(x => _mapper.Map<Model.Ocjena>(x)).ToList();
        }
        public Model.Ocjena GetById(int id)
        {
            var entity = _context.Ocjenas.Find(id);
            return _mapper.Map<Model.Ocjena>(entity);
        }
    }
}
