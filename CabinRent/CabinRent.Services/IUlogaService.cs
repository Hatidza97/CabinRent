using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IUlogaService
    {
        Model.Uloga GetById(int id);
        bool Delete(int id);
        //List<Model.Uloga> Get(UlogaSearchRequest request);
        //Model.Uloga Update(int id, UlogaUpdateRequest request);
    }
}
