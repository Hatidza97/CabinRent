using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipObjektaSllikeController:ControllerBase
    {
        private readonly ITipObjektaSLlikeService _service;
        public TipObjektaSllikeController(ITipObjektaSLlikeService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public Model.TipObjektaSllike GetByID(int id)
        {
            return _service.GetByID(id);
        }
        [HttpGet]
        public ActionResult<List<Model.TipObjektaSllike>> Get([FromQuery] ObjekatSlikeSearchRequest search = null)
        {
            return _service.Get(search);
        }
        [HttpPost]
        public ActionResult<Model.TipObjektaSllike> Insert(TipObjektaSllikeInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
