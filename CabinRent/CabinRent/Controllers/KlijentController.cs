using CabinRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KlijentController : ControllerBase
    {
        private readonly IKlijentService _service;
        public KlijentController(IKlijentService service)
        {
            _service = service;

        }
        [HttpGet("{id}")]
        public Model.Klijent GetByID(int id)
        {
            return _service.GetById(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
        //[HttpGet]
        //public ActionResult<List<Model.Klijent>> Get([FromQuery] KlijentSearchRequest search = null)
        //{
        //    return _service.Get(search);
        //}
        //[HttpPut("{id}")]
        //public ActionResult<Model.Klijent> Update(int id, [FromBody] KlijentUpdateRequest request)
        //{
        //    return _service.Update(id, request);
        //}
        //[HttpPost]
        //public ActionResult<Model.Klijent> Insert(KlijentInsertRequest request)
        //{
        //    return _service.Insert(request);
        //}
    }
}
