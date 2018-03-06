using System;
using NasaImage;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var image = Image.RequestApod();
            image.Wait();

            Console.WriteLine($"Image Request Success: {image.Result.Url}");

            Console.ReadLine();
        }
    }
}
