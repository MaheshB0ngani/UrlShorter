using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener.Core
{
    /// <summary>
    /// https://github.com/delight-im/ShortURL/blob/master/C%23/ShortURL.cs
    /// </summary>
    public class UrlShortener1
    {
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789"; //0123
        public static readonly int Base = Alphabet.Length;

        // Bijective functions
        // starbukcs.com --> 1001
        // starbukcs.com --> 1424
        // starbukcs.com --> 1001 ->afsasfba

        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        // afsasfba --> 1001 then query 
        public static int Decode(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            return i;
        }

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
