using HashidsNet;
using System;
using UrlShortener.Core;

namespace UrlShortener.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            //UrlShortener1.Run();
            //Core.UrlShortener.Run();

            var hashids = new Hashids("this is my salt");
            var hash = hashids.Encode(12345);
            System.Console.WriteLine(hash);

            System.Console.ReadLine();
        }
    }
}
