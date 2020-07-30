using System;
using System.IO;
using UrlShortener.Core.Models;
using UrlShortener.Data;

namespace UrlShortener.Core
{
    public class UrlManager
    {

      
        public string Shorten(string originalUrl)
        {
            try
            {
                var url = new Uri(originalUrl);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Invalid URL", ex); //TODO: 
            }

            UrlEntity urlEntity = FindUrl(originalUrl);

            if (urlEntity != null)
            {
                return urlEntity.ShortUrl;
            }

            string shortenedUrl = GenerateShortenedUrl(originalUrl);

            SaveToStore(originalUrl, shortenedUrl, DateTime.Now);

            return shortenedUrl;
        }

        public string GetOriginalUrl(string shortKey)
        {
            UrlRepo repo = new UrlRepo();
            return repo.GetOriginalUrlByKey(shortKey);
        }

        //private UrlEntity FindUrlByKey(string shortKey)
        //{
        //    UrlRepo repo = new UrlRepo();
        //    return repo.FindUrlByKey(shortKey);
        //}

        private UrlEntity FindUrl(string originalUrl)
        {
            bool generateNewAlways = true;
            if (generateNewAlways)
            {
                return null;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private bool SaveToStore(string originalUrl, string shortenedUrl, DateTime now)
        {
            UrlRepo repo = new UrlRepo();
            return  repo.SaveToStore(originalUrl, shortenedUrl, now);
        }

        private string GenerateShortenedUrl(string originalUrl)
        {
            string shortenedUrl = Guid.NewGuid().ToString("N").Substring(0, 6).ToLower();
            return shortenedUrl;
        }
    }

}
