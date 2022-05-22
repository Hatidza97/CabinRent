using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinRent.Services
{
    public interface IKorisniciService
    {
        //List<Model.Korisnik> Get();
        Model.Korisnik GetById(int id);
        bool Delete(int id);
        //Model.Korisnik Insert(KorisniciInsertRequest request);
        //List<Model.Korisnik> Get(KorisniciSearchRequest request);
        //List<Model.Korisnik> GetRegistracija(KorisniciSearchRequest request);
        //Model.Korisnik Update(int id, KorisniciUpdateRequest request);
        //Task<Model.Korisnik> Login(KorisniciLoginRequest request);
        //ActionResult<Model.Korisnik> SignUp(KorisniciUpdateRequest request);
    }
}
