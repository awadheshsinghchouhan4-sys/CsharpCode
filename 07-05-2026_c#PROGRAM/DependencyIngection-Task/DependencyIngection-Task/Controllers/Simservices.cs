using DependencyIngection_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyIngection_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Simservices : ControllerBase
    {
        public readonly ISim _sim;

        public Simservices(ISim sim)
        {
            _sim = sim;
        }

        [HttpGet]

        public IActionResult Get()
        {
           string recharge= _sim.RechargePlan();
            string org = _sim.SimOrgainization();
            return Ok(new { recharge, org });
        }

    }
}
