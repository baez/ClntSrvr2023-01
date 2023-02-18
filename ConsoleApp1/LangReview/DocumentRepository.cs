using DataModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1.LangReview
{
    public class DocumentRepository : IDocumentRepository, ILanguageInterpreter
    {
        private List<Document> _documents;

        public DocumentRepository()
        {
            _documents = new List<Document>();
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
            _documents.Add(document);    
        }

        public Document Get(string Id)
        {
            foreach (Document document in _documents) 
            { 
                if (document.Id == Id) return document;
            }

            return null;
        }

        public async Task<string> GetFromService(string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                // https://localhost:44385/api/document?id=ha12
                var url = $"https://localhost:44385/api/document?id={id}";
                documentAsString = await httpClient.GetStringAsync(url);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documentAsString;
        }

        public Document Get2(string Id)
        {
            return _documents.Find(x => x.Id == Id);
        }

        public List<Document> GetAll(string title)
        {
            var result = new List<Document>();
            foreach (Document document in _documents) 
            { 
                if (document.Title == title) 
                {
                    result.Add(document);
                }
            }

            return result;
        }

        public List<Document> GetAll2(string title) 
        {
            return _documents.FindAll(x => x.Title == title);
        }

        public void Remove(Document document)
        {
            _documents.Remove(document);
        }

        public void Update(string id, Document document)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {

        }

        public void Interpret(string text)
        {

        }
    }
}
