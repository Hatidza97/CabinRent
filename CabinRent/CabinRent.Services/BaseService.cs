using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class BaseService<Tmodel, Tsearch, Tdatabase> : IService<Tmodel, Tsearch> where Tdatabase : class where Tsearch : class
    {
        protected readonly eRentContext _context;
        protected readonly IMapper _mapper;

        public BaseService(eRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<Tmodel> Get(Tsearch search = null)
        {
            return _mapper.Map<List<Tmodel>>(_context.Set<Tdatabase>().ToList());
        }

        public virtual Tmodel GetByID(int id)
        {
            return _mapper.Map<Tmodel>(_context.Set<Tdatabase>().Find(id));
        }
    }
}
