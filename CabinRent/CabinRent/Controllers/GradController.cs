using CabinRent.Model;
using CabinRent.Model.SearchObjects;
using CabinRent.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabinRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradController : BaseController<Model.Grad, GradSearchRequest>
    {
        public GradController(IService<Grad, GradSearchRequest> service) : base(service)
        {

        }
    }
}
