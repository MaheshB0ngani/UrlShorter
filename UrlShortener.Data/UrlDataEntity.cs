using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Data
{
    public class UrlDataEntity
    {
        public string Url { get; set; }
        public string ShortUrl { get; set; } // currenly key
        public DateTime GeneratedTime { get; set; }
    }
}
