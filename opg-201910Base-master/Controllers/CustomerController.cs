using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using opg_201910_interview.Services.IO;

namespace opg_201910_interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private IConfiguration _configuration;
        private ReadService _readService;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _readService = new ReadService();
        }

        /// <summary>
        /// Gets the files that matches the custom sort/filter on the appsettings
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFiles")]
        public IActionResult GetFiles()
        {
            // gets the path from the settings, but should come from db
            string targetDirectory = _configuration["ClientSettings:FileDirectoryPath"].Replace("/", "\\");
            // should come from db
            string[] customSort = { "shovel", "waghor", "blaze", "discus" };

            return Ok(_readService.ReadDirectory(targetDirectory, customSort).Select(f => f.Name));
        }
    }
}