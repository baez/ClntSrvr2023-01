using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LangReview
{
    public interface IDocumentRepository
    {
        Document Get(string Id);

        Task<string> GetFromService(string Id);

        List<Document> GetAll(string title);

        void Add(Document document);

        void Remove(Document document);

        void Update(string id, Document document);
    }
}
