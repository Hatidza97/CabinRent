using CabinRent.Model.Requests;
using CabinRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DetaljiRezervacijeController : ControllerBase
    {
        private readonly IDetaljiRezervacijeService _service;
        public DetaljiRezervacijeController(IDetaljiRezervacijeService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.DetaljiRezervacije> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Model.DetaljiRezervacije GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPut("{id}")]
        public Model.DetaljiRezervacije Update(int id, [FromBody] DetaljiRezervacijeUpdateRequest request)
        {
            return _service.Update(id, request);
        }

    }
}
