using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core
{
    public class AutoIncrmentGenerator
    {

        private static readonly Lazy<AutoIncrmentGenerator> lazy = new Lazy<AutoIncrmentGenerator>(() => new AutoIncrmentGenerator());

        public static AutoIncrmentGenerator Instance { get { return lazy.Value; } }

        private AutoIncrmentGenerator()
        {

        }

        static AutoIncrmentGenerator()
        {

        }

        private static int id = 1;

        public int GenerateId()
        {
            return id++;
        }
    }
}
