using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IOcjenaService
    {
        List<Model.Ocjena> Get();
        Model.Ocjena GetById(int id);
    }
}
