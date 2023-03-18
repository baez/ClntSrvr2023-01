namespace DocumentClientConsole
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DataModels;
    using Newtonsoft.Json;

    internal class DocumentAPITests
    {
        static async Task Main(string[] args)
        {
            var testApp = new DocumentAPITests();
            await testApp.GetDocumentTest();   
        }

        private async Task GetDocumentTest()
        {
            Console.WriteLine("Get Document Test");

            var documentClientProgram = new DocumentAPITests();
            // https://localhost:44385/api/document?id=ha12 -- https://localhost:44385/api/document?id={id}";
            // localhost:44385 https://docservgbk20230224.azurewebsites.net/api/document

            // use for running the version published on cloud
            var baseUri = "https://docservgbk20230224.azurewebsites.net/api/document";

            // use this Uri for tests with localhost (when running the service on local box)
            var localBaseUri = "https://localhost:44385/api/document/id";
            var id = "3";
            var doc = await documentClientProgram.GetDocument(localBaseUri, id);

            if (string.IsNullOrWhiteSpace(doc) 
                || !doc.Contains("testKeyName") || !doc.Contains("testKeyword"))
            {
                Console.WriteLine($"*** TEST FAILED *** {localBaseUri}");
            }
            else
            {
                // Desrialization of a string received by the client back into an in-memory object
                var document = JsonConvert.DeserializeObject<Document>(doc);
                Console.WriteLine("Test passed :) ");
                Console.WriteLine($"Title received from the service: {document.Title}");
            }

            Console.WriteLine(doc);
        }

        public async Task<string> GetDocument(string baseUri, string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                var uri = $"{baseUri}?val={id}";
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
