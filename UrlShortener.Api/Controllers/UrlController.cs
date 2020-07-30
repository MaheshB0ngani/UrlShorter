using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Core;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;

        public UrlController(ILogger<UrlController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{key}")]
        public ActionResult Get(string key)
        {
            IDictionary<int, int> i;
            UrlManager urlManager = new UrlManager();
            string urlString = urlManager.GetOriginalUrl(key);
            if (!string.IsNullOrWhiteSpace(urlString))
            {
                return Redirect(urlString);
            }
            return null; // TODO: invalid request url
        }

        [HttpPost]
        [Route("shorten")]
        public ActionResult Post([FromBody] string url)
        {
            UrlManager urlManager = new UrlManager();
            var hash = urlManager.Shorten(url);
            var res = new { key = hash, ShortUrl = $"{(Request.IsHttps ? "https://" : "http://")}{ Request.Host.Value}/{hash}" };
            return Ok(res);
        }
    }
}