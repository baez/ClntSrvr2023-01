namespace ConsoleApp1
{
    using System;
    using ConsoleApp1.Network;

    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.TestHostInformation();
        }

        private void TestHostInformation()
        {
            var hostInfo = new HostInformation().GetHostIPAddresses("www.ibm.com");
        }
    }
}
