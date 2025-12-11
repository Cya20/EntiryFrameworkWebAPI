using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntiryFrameworkWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DefaultController : ControllerBase
    {
        [Route("/")]
        [Route("/docs")]
        [Route("/swagger")]

        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
