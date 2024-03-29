﻿using CabinRent.Model;
using CabinRent.Model.Requests;
using CabinRent.Model.SearchObjects;
using CabinRent.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UlogaController : ControllerBase
    {
        private readonly IUlogaService _service;
        public UlogaController(IUlogaService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public Uloga GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
        [HttpGet]
        public ActionResult<List<Model.Uloga>> Get([FromQuery] UlogaSearchRequest search = null)
        {
            return _service.Get(search);
        }
        [HttpPut("{id}")]
        public ActionResult<Model.Uloga> Update(int id, [FromBody] UlogaUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
