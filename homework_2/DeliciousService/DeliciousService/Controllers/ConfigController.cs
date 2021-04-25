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
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;

        public ConfigController(ILogger<ConfigController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Dictionary<string, string> Get()
        {
            var conf = new Dictionary<string, string>();
            conf.Add("MachineName", Environment.MachineName);
            conf.Add("CurrentDirectory", Environment.CurrentDirectory);
            conf.Add("CommandLine", Environment.CommandLine);
            conf.Add("SystemDirectory", Environment.SystemDirectory);
            conf.Add("UserName", Environment.UserName);
            conf.Add("UserDomainName", Environment.UserDomainName);
            conf.Add("Version", Environment.Version.ToString());
            conf.Add("ProcessId", Environment.ProcessId.ToString());
            conf.Add("ProcessorCount", Environment.ProcessorCount.ToString());
            conf.Add("OSVersion", Environment.OSVersion.ToString());
            conf.Add("ENV: GREETING", Environment.GetEnvironmentVariable("GREETING"));
            conf.Add("ENV: DATABASE_URI", Environment.GetEnvironmentVariable("DATABASE_URI"));

            return conf;
        }
    }
}