namespace ConsoleApp1
{
    using System;
    using ConsoleApp1.Network;
    using ConsoleApp1.LangReview;

    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.TestHostInformation();

            var exploreLang = new ExploreCollections();
            exploreLang.UsePrintNames();
        }

        private void TestHostInformation()
        {
            var hostInfo = new HostInformation().GetHostIPAddresses("www.ibm.com");
        }
    }
}
