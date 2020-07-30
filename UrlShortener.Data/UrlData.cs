using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Data
{
    public sealed class UrlData
    {
        private static readonly Lazy<UrlData> lazy = new Lazy<UrlData>(() => new UrlData());

        internal void Add(UrlDataEntity UrlDataEntity)
        {
            DataList.Add(UrlDataEntity);
        }

        internal bool Exists(UrlDataEntity UrlDataEntity)
        {
            return DataList.Exists((entity) => entity.Url == UrlDataEntity.Url);
        }

        internal UrlDataEntity FindByKey(string shortKey) 
        {
            return DataList.Find((entity) => entity.ShortUrl == shortKey);
        }

        public static UrlData Instance { get { return lazy.Value; } }

        private UrlData()
        {
            //Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UrlDataEntity>>("");
            DataList = new List<UrlDataEntity>();
            Data = DataList;
        }

        public IReadOnlyCollection<UrlDataEntity> Data { get; set; }
        private List<UrlDataEntity> DataList { get; set; }


    }
}
