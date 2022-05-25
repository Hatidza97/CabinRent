using CabinRent.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IGradService
    {
        List<Model.Grad> Get(GradSearchRequest request);
        Model.Grad GetById(int id);
    }
}
