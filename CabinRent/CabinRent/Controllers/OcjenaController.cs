using CabinRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OcjenaController : ControllerBase
    {
        private readonly IOcjenaService _service;
        public OcjenaController(IOcjenaService service)
        {
            _service = service;
        }
        [HttpGet]
        public IList<Model.Ocjena> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Model.Ocjena GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
