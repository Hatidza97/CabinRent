using CabinRent.Model;
using CabinRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;

        }
        //[HttpGet]
        //public IList<Model.Korisnik> Get()
        //{
        //    return _service.Get();
        //}
        [HttpGet("{id}")]
        public Korisnik GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
        //[HttpGet]
        //public ActionResult<List<Model.Korisnik>> Get([FromQuery] KorisniciSearchRequest search = null)
        //{
        //    return _service.Get(search);
        //}
        //[HttpPost]
        //public ActionResult<Model.Korisnik> Insert(KorisniciInsertRequest request)
        //{
        //    return _service.Insert(request);
        //}
        //[HttpPut("{id}")]
        //public ActionResult<Model.Korisnik> Update(int id, [FromBody] KorisniciUpdateRequest request)
        //{
        //    return _service.Update(id, request);
        //}
        //[HttpPost("signUp")]
        //public ActionResult<Model.Korisnik> SignUp(KorisniciUpdateRequest request)
        //{
        //    return _service.SignUp(request);
        //}
    }
}
