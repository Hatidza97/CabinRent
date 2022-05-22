using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IObjekatService
    {
        Model.Objekat GetByID(int id);
        bool Delete(int id);
        List<Model.Objekat> Get(ObjekatSearchRequest request);
        Model.Objekat Update(int id, ObjekatUpdateRequest request);
        Model.Objekat Insert(ObjekatInsertRequest request);
        //Model.Objekat SearchTip(ObjekatTipSearchRequest request);
    }
}
