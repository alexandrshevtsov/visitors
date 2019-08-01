using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<string> Delta() => Ok(service.GetDelta());
    }
}
