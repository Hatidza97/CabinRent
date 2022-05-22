using AutoMapper;
using CabinRent.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public class DetaljiRezervacijeService : IDetaljiRezervacijeService
    {
        private readonly IMapper _mapper;
        public eRentContext _context;
        public DetaljiRezervacijeService(eRentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.DetaljiRezervacije> Get()
        {
            return _context.DetaljiRezervacijes.ToList().Select(x => _mapper.Map<Model.DetaljiRezervacije>(x)).ToList();

        }
        public Model.DetaljiRezervacije GetById(int id)
        {
            var entity = _context.DetaljiRezervacijes.Find(id);
            return _mapper.Map<Model.DetaljiRezervacije>(entity);
        }

        //public Model.DetaljiRezervacije Update(int id, DetaljiRezervacijeUpdateRequest request)
        //{
        //    var entity = _context.DetaljiRezervacijes.Find(id);

        //    _context.DetaljiRezervacijes.Attach(entity);
        //    _context.DetaljiRezervacijes.Update(entity);
        //    _mapper.Map(request, entity);
        //    _context.SaveChanges();

        //    return _mapper.Map<Model.DetaljiRezervacije>(entity);
        //}

    }
}
