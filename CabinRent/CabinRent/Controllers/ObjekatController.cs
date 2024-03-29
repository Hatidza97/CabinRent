﻿using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ObjekatController : ControllerBase
    {
        private readonly IObjekatService _service;
        public ObjekatController(IObjekatService service)
        {
            _service = service;
        }
        //[HttpGet]
        //public IList<Model.Objekat> Get()
        //{
        //    return _service.Get();
        //}
        [HttpGet("{id}")]
        public Model.Objekat GetByID(int id)
        {
            return _service.GetByID(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
        [HttpPut("{id}")]
        public ActionResult<Model.Objekat> Update(int id, [FromBody] ObjekatUpdateRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public ActionResult<Model.Objekat> Insert(ObjekatInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Model.Objekat>> Get([FromQuery] ObjekatSearchRequest search = null)
        {
            return _service.Get(search);
        }
        //public ActionResult<Model.Objekat> SearchTip([FromQuery] ObjekatTipSearchRequest search)
        //{
        //    return _service.SearchTip(search);
        //}
    }
}
