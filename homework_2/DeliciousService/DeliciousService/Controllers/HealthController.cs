using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using DeliciousService.SomeCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DeliciousService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        public record HealthDto
        {
            public string Status { get; init; }
        }

        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HealthDto Get()
        {
            return new HealthDto()
            {
                Status = "OK"
            };
        }
    }
}