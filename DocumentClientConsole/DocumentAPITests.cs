namespace DocumentClientConsole
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using DataModels;
    using Newtonsoft.Json;

    internal class DocumentAPITests
    {
        static async Task Main(string[] args)
        {
            var testApp = new DocumentAPITests();   
            await testApp.CreateDocument_WhenDocumentIsNew_ShouldCreateDocument();
            await testApp.GetDocument_WhenDocumentExists_ShouldReturnDocument();
        }

        private async Task CreateDocument_WhenDocumentIsNew_ShouldCreateDocument()
        {
            var document = new Document()
            {
                Id = "901Test1",
                Title = "TitleTest1",
                Text = "TextTest1",
                Author = "AuthorTest1"
            };

            var serializedDocument = JsonConvert.SerializeObject(document);
            var content = new StringContent(serializedDocument, UnicodeEncoding.UTF8, "application/json");

            var localBaseUri = "https://localhost:44385/api/document/document";
            var httpClient = new HttpClient();
            var postResult = await httpClient.PostAsync(localBaseUri, content);
        }

        private async Task GetDocument_WhenDocumentExists_ShouldReturnDocument()
        {
            Console.WriteLine("Get Document Test");

            var documentClientProgram = new DocumentAPITests();

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
