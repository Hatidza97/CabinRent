using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface ITipObjektaSLlikeService
    {
        List<Model.TipObjektaSllike> Get(ObjekatSlikeSearchRequest request);
        Model.TipObjektaSllike GetByID(int id);
        Model.TipObjektaSllike Insert(TipObjektaSllikeInsertRequest request);

    }
}
