using DependencyinjectionExamplelifeprocess.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionExamplelifeprocess.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGuidService _service1;
        private readonly IGuidService _service2;


        public HomeController(IGuidService service1, IGuidService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }


        public IActionResult Index()
        {
            Console.WriteLine(_service1.GetGuid());
            Console.WriteLine(_service2.GetGuid());
            return Ok();
        }

    }
}
