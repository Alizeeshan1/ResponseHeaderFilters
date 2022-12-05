using Microsoft.AspNetCore.Mvc;
using WebApiFilter.Filters;

namespace WebApiFilter.Controllers
{
   // [Log]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
