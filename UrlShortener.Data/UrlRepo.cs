using System;

namespace UrlShortener.Data
{
    public class UrlRepo
    {

        //public string GetShortUrl()
        //{

        //}
        //public UrlEntity FindUtlEntity()
        //{

        //}
        public bool SaveToStore(string originalUrl, string shortenedUrl, DateTime creationTime)
        {
            try
            {
                UrlData.Instance.Add(new UrlDataEntity()
                {
                    Url = originalUrl,
                    ShortUrl = shortenedUrl,
                    GeneratedTime = creationTime
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UrlDataEntity FindUrlByKey(string shortKey)
        {
            return UrlData.Instance.FindByKey(shortKey);
        }
        public string GetOriginalUrlByKey(string shortKey)
        {
            var entiry = UrlData.Instance.FindByKey(shortKey);
            return entiry?.Url;
        }
    }
}
