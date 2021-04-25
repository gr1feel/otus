using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliciousService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        public record VersionDto
        {
            public int Homework { get; set; }
            public int Version { get; set; }
        }

        private readonly ILogger<VersionController> _logger;

        public VersionController(ILogger<VersionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public VersionDto Get()
        {
            return new() {Homework = 2, Version = 5};
        }
    }
}