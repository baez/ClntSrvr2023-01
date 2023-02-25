using System;
using DataModels;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentRepository documentRepository = new DocumentRepository();

        /// <summary>
        /// Sample call uri https://localhost:44385/api/document?id=3
        /// Azure uri https://docservgbk20230224.azurewebsites.net/api/document?id=3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<Document> Get(string id)
        {
            Document document = documentRepository.Get(id);

            if (document == null)
            {
                if (Convert.ToInt16(id) == 1)
                {
                    document = new Document()
                    {
                        Id = id,
                        Title = "cstp 1303 news today 2/25 9 AM",
                        Author = "George Karim",
                        Text = "Due to weather conditions, our class is online today :)"
                    };
                }
                else
                {
                    document = new Document()
                    {
                        Id = id,
                        Title = "cstp 1303 topics today",
                        Author = "George Karim",
                        Text = "Consuming a Web API"
                    };
                }
            }

            return document;
        }
    }

    //[HttpGet]
    //[Route("api/[controller]")]

    //public ActionResult<List<Document>> GetAll(string author, string title)
    //{

    //}
}
