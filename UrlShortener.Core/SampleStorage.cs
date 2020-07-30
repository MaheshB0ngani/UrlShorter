using System;
using System.Collections.Generic;
using System.Text;
using NoDb;

namespace UrlShortener.Core
{
    class SampleStorage
    {
        public void SampleStorageImpl()
        {
            NoDb.IStringSerializer<object> ser = new StringSerializer<object>();


        }
    }
}