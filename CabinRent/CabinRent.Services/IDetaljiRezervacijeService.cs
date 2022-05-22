using CabinRent.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IDetaljiRezervacijeService
    {
        List<Model.DetaljiRezervacije> Get();
        Model.DetaljiRezervacije GetById(int id);
        Model.DetaljiRezervacije Update(int id, DetaljiRezervacijeUpdateRequest request);
    }
}
