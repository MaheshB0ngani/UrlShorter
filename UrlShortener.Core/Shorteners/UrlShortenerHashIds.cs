using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener.Core
{
    public class UrlShortenerHashIds
    {
        private static readonly Lazy<UrlShortenerHashIds> lazy = new Lazy<UrlShortenerHashIds>(() => new UrlShortenerHashIds());

        public static UrlShortenerHashIds Instance { get { return lazy.Value; } }


        private static readonly Hashids hashids;

        private UrlShortenerHashIds()
        {
            //hashids = new Hashids("this is my salt");
        }
        static UrlShortenerHashIds()
        {
            hashids = new Hashids("this is my salt", minHashLength: 5, alphabet: Alphabet);
        }

        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static readonly int Base = Alphabet.Length;

        // Bijective functions
        // starbukcs.com --> 1001
        // starbukcs.com --> 1424
        // starbukcs.com --> 1001 ->afsasfba

        public static string Encode(int i)
        {
            return hashids.Encode(i);
        }

        // afsasfba --> 1001 then query 
        public static int Decode(string s)
        {
            return (int)(hashids.Decode(s)?[0]);
            //return GetElementOrDefault(hashids.Decode(s), 0, -1);
        }

        //public static bool TryGetElement<T>(this T[] array, int index, out T element)
        //{
        //    if (index < array.Length)
        //    {
        //        element = array[index];
        //        return true;
        //    }
        //    element = default(T);
        //    return false;
        //}
        //public static T GetElementOrDefault<T>(this T[] array, int index, T defaultValue)
        //{
        //    return TryGetElement<T>(array, index, out T element) ? element : defaultValue;
        //}

        public static void Run()
        {
            // Simple test of encode/decode operations
            for (var i = 0; i < 10000; i++)
            {
                var encoded = Encode(i);
                var decoded = Decode(encoded);
                System.Console.WriteLine($"{i} Encoded as {encoded} Decoded As {decoded}");
                if (decoded != i)
                {
                    break;
                }
            }
        }
    }
}
