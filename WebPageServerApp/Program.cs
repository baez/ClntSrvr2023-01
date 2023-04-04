namespace WebPageServerApp
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var webPageServer = new WebPageServer("http://localhost:51199/", @"c:\bekari\srvrData");

            try
            {
                webPageServer.Start();
                Console.WriteLine("Server started ..");
                Console.ReadLine();
            }
            finally
            {
                webPageServer.Stop();
            }
        }
    }
}
