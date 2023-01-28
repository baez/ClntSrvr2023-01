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

            program.InheritanceExamples();
            
            var exploreLang = new ExploreCollections();
            exploreLang.UsePrintNames();

            int x = 123; // 32-bit integer
            long y = x;  // 64-bit intetger - implicit conversion
            short z = (short)x; // explicit conversion to a 16-bit integer

            Point p1 = new Point();
            p1.x = 5;
            p1.y = 10;

            Point p2 = p1; // causes copy of value
            p2.x = 15;

            Dot d1 = new Dot();
            d1.x = 7;
            Dot d2 = d1;  // copies d1 reference

            Console.WriteLine("d1.x: {0} d2.x: {1}", d1.x, d2.x);

            d1.x = 19;
            Console.WriteLine("d1.x: {0} d2.x: {1}", d1.x, d2.x);

            Folder folder1 = new Folder(0);
            Folder.Name = "asd";
        }

        private void TestHostInformation()
        {
            var hostInfo = new HostInformation().GetHostIPAddresses("www.ibm.com");
            Folder folder2 = new Folder();
        }

        private void InheritanceExamples()
        {
            Stock myFirstStock = new Stock()
            {
                Name = "stock1",
                Shares = 5
            };

            House myHouse = new House
            {
                Name = "smallHouse",
                Mortgage = 25000
            };

            this.Display(myFirstStock);
            this.Display(myHouse);
        }

        /// <summary>
        /// Polymorphism works on the basis that subclasses have all 
        /// the features of the base class
        /// </summary>
        /// <param name="asset"></param>
        public void Display(Asset asset)
        {
            Console.WriteLine("Asset.NAme:{0}", asset.Name);
        }
    }

    public struct Point { public int x; public int y; }

    public class Dot
    { 
        public int x; 
        public int y; 
    }
}
