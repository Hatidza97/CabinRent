using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IKlijentService
    {
        Model.Klijent GetById(int id);
        bool Delete(int id);
        //Model.Klijent Update(int id, KlijentUpdateRequest request);
        //List<Model.Klijent> Get(KlijentSearchRequest request);
        //Model.Klijent Insert(KlijentInsertRequest request);

    }
}
