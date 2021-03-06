using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliciousService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly ILogger<VersionController> _logger;

        public VersionController(ILogger<VersionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "{\"version\": \"4\"}";
        }
    }
}