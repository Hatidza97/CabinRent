using AutoMapper;
using CabinRent.Services.Database;
using Microsoft.EntityFrameworkCore;
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
            var query = _context.Ocjenas
                  .Include(x => x.Objekat)
                  .Include(x => x.Klijent)
                  .AsQueryable();
            var list = query.ToList();
            return _mapper.Map<List<Model.Ocjena>>(list);
        }
        public Model.Ocjena GetById(int id)
        {
            var entity = _context.Ocjenas.Find(id);
            return _mapper.Map<Model.Ocjena>(entity);
        }
    }
}
