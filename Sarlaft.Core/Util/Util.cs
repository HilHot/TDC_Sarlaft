using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sarlaft.Core.Util
{
    public class Util : IUtil
    {
        private readonly ILogger<Util> _logger;
        private readonly HttpClient _client = new();
        public Util(ILogger<Util> logger) {
            _logger = logger;
        }

        /// <summary>
        /// Call an external restful service (GET Method) and returns the string result
        /// </summary>
        /// <param name="url">Service url</param>
        /// <param name="headers">Service headers</param>
        /// <param name="parameters">Service parameters</param>
        public string GetRestfulService_Str(string url, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            var strResult = string.Empty;
            
            url = LoadRestInfo(url, headers, parameters);

            var response = _client.GetStringAsync(new Uri(url));
            try
            {
                strResult = response.Result;
            }
            catch (Exception e)
            {
                _logger.LogError("GetRestfulService_Str, Mensaje: "+e.Message);
            }            

            return strResult;
        }

        internal String LoadRestInfo(string url, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            //Load the service headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            //Load the service parameters
            var builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    query[param.Key] = param.Value;
                }
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
