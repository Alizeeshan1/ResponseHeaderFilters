
using Microsoft.AspNetCore.Mvc;
using WebApiFilter.Filters;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cpm.Web.Api.Controllers
{
    public class InputModel
    {
        public string Value { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // GET: api/<HelloController>
        [ServiceFilter(typeof(OtherFilters), Order = 1)]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Thread.Sleep(1000);
            return new string[] { "value1", "value2" };
        }
    }
}
