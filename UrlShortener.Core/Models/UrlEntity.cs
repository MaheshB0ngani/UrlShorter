using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Models
{
    public class UrlEntity
    {
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime GeneratedTime { get; set; }
    }
}
