using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sarlaft.Core;
using Sarlaft.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sarlaft.Services.Controllers
{
    public class SarlaftController : ControllerBase
    {
        private readonly ILogger<SarlaftController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IConsultarSarlaft _consultarSarlaft;

        public SarlaftController(ILogger<SarlaftController> logger, IConfiguration configuration
            , IConsultarSarlaft consultarSarlaft) {
            _logger = logger;
            _configuration = configuration;
            _consultarSarlaft = consultarSarlaft;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public List<LaftDTO> ConsultarSarlaft([FromBody]Dictionary<String, String> qparams)
        {

            return _consultarSarlaft.QueryLAFT(qparams); 
        }
    }
}
