using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeliciousService.Controllers
{
    [ApiController]
    [Route("")]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public record HomeDto
        {
            public string MachineName { get; init; }
            public string RuntimeVersion { get; init; }
        }
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HomeDto Get()
        {
            return new HomeDto()
            {
                MachineName = Environment.MachineName,
                RuntimeVersion = Environment.Version.ToString()
            };
        }
    }
}