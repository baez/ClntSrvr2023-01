using DataModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Interfaces;

namespace Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private static Document defaultDoc1 = new Document()
        {
            Id = "3",
            Title = "cstp 1303 Summer 2022",
            Author = "George K.",
            Text = "Notes from summer 2022 :)"
        };

        private static Document defaultDoc2 = new Document()
        {
            Id = "71",
            Title = "cstp 1303 Winter 2022",
            Author = "George K.",
            Text = "Notes from winter 2022"
        };

        private static List<KeyValuePair<string, Document>> defaultDocuments = new List<KeyValuePair<string, Document>>()
        {
            new KeyValuePair<string, Document>("3", defaultDoc1),
            new KeyValuePair<string, Document>("71", defaultDoc2)
        };

        private static Dictionary<string, Document> _documents = new Dictionary<string, Document>(defaultDocuments);

        public DocumentRepository()
        {
        }

        public bool IsInitialized 
        {  
            get 
            { 
                return false;  
            } 
        }

        public void Add(Document document)
        {
            _documents.Add(document.Id, document);
        }

        public Document Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id), "id cannot be null or empty.");
            }

            if (_documents.TryGetValue(id, out Document value))
            {
                return value;
            }

            return null;
        }

        public async Task<string> GetFromService(string baseUri, string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                // https://localhost:44385/api/document?id=ha12 -- https://localhost:44385/api/document?id={id}";
                var uri = $"{baseUri}?id={id}";
                documentAsString = await httpClient.GetStringAsync(uri);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documentAsString;
        }

        //public void Remove(Document document)
        //{
        //    _documents.Remove(document);
        //}

        //public void Update(string id, Document document)
        //{
        //    throw new NotImplementedException();
        //}

        public void Initialize()
        {

        }

        public void Interpret(string text)
        {

        }

        public Task<string> GetFromService(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetAll(string title)
        {
            throw new NotImplementedException();
        }

        public void Remove(Document document)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Document document)
        {
            throw new NotImplementedException();
        }
    }
}
