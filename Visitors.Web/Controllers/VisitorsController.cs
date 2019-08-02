using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Visitors.Services.Contracts;

namespace Visitors.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        IVisitorService service;

        public VisitorsController(IVisitorService service)
        {
            this.service = service;
        }

        //GET api/visitors/delta
        [HttpGet("delta")]
        public async Task<ActionResult<string>> DeltaAsync() => Ok(await service.GetDelta());
    }
}
