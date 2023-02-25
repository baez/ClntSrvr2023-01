namespace DocumentClientConsole
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal class DocumentClientProgram
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello from Document Client Console App!");

            var documentClientProgram = new DocumentClientProgram();
            var baseUri = "https://docservgbk20230224.azurewebsites.net/api/document"; // localhost:44385 https://docservgbk20230224.azurewebsites.net/api/document
            var id = "3";
            var doc = await documentClientProgram.GetDocument(baseUri, id);

            Console.WriteLine(doc);
        }

        public async Task<string> GetDocument(string baseUri, string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                // https://localhost:44385/api/document?id=ha12 -- https://localhost:44385/api/document?id={id}";
                var uri = $"{baseUri}?id={id}";
                documentAsString = await httpClient.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documentAsString;
        }
    }
}
