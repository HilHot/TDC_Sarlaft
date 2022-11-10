using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sarlaft.Core.Util;
using Sarlaft.Domain.Dto;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sarlaft.Core
{
    public class ConsultarSarlaft : IConsultarSarlaft
    {
        private readonly ILogger<ConsultarSarlaft> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUtil _util;
        #region
        private readonly String url;
        private readonly String token;
        #endregion
        public ConsultarSarlaft(ILogger<ConsultarSarlaft> logger, IConfiguration configuration
            , IUtil Util) {
            _logger = logger;
            _configuration = configuration;
            _util = Util;

            url = _configuration["Sarlaft:Url"];
            token = _configuration["Sarlaft:Token"];
        }
        public List<LaftDTO> QueryLAFT(Dictionary<String, String> qparams)
        {
            List<LaftDTO> laftObj = new();
            try {
                #region Service Query and params

                //Include the headers
                var headers = new Dictionary<String, String>();
                headers.Add("authorization", token);

                //Token
                qparams.Add("Token", token);

                #endregion

                var strResult = _util.GetRestfulService_Str(url, headers, qparams);
                var formatResult = strResult.Replace("\\\"", "\"").Replace("\\\"", "\"").Trim('"');

                laftObj = JsonSerializer.Deserialize<List<LaftDTO>>(formatResult);

            }
            catch (Exception e) {
                _logger.LogError("QueryLAFT, mensaje: "+e.Message);
            }
            return laftObj;
        }
    }
}
