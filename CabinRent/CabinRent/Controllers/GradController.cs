using CabinRent.Model;
using CabinRent.Model.SearchObjects;
using CabinRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradController : ControllerBase
    {
        private readonly IGradService _service;
        public GradController(IGradService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Grad>> Get([FromQuery] GradSearchRequest search = null)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public Model.Grad GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
