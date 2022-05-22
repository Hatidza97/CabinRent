using CabinRent.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface ITipObjektumService
    {
        //List<Model.TipObjektum> Get();
        Model.TipObjektum GetById(int id);
        List<Model.TipObjektum> Get(TipObjektumSearchRequest search);
    }

}
