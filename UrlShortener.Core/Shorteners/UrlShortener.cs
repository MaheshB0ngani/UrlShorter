using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener.Core
{
    public class UrlShortener
    {
        private static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static int BASE = ALPHABET.Length;

        // Bijective functions
        // starbukcs.com --> 1001
        // starbukcs.com --> 1424
        // starbukcs.com --> 1001 ->afsasfba
        public static string Encode(int num)
        {
            StringBuilder sb = new StringBuilder();
            while (num > 0)
            {
                sb.Append(ALPHABET[num % BASE]);
                num /= BASE;
            }
            return new string(sb.ToString().Reverse().ToArray());
        }

        public static int Decode(string str)
        {
            int num = 0;
            for (int i = 0; i < str.Length; i++)
                num = num * BASE + ALPHABET.IndexOf(str[i]);
            return num;
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
