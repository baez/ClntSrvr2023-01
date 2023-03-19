using System;
using System.Collections.Generic;
using System.Net;

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
        /// GET a single document from the service 
        /// [Route("api/document/id")]
        /// 2/25 ==> New sample uri: https://localhost:44385/api/document/id?val=3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/id")]
        public ActionResult<Document> Get(string val)
        {
            Document document = documentRepository.Get(val);

            if (document == null)
            {
                throw new InvalidOperationException($"{(int)HttpStatusCode.NotFound} Document not found");
            }

            return document;
        }


        /// <summary>
        /// sample call uri: https://localhost:44385/api/document/author?val=3
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/author")]

        public ActionResult<List<Document>> GetAll(string val)
        {
            var docs = new List<Document>()
            {
                new Document()
                {
                    Id = "101",
                    Title = "cstp 1303 news today 2/25 9 AM",
                    Author = "George Karim",
                    Text = "Due to weather conditions, our class is online today :)"
                },
                new Document()
                {
                    Id = "102",
                    Title = "cstp 1303 topics today",
                    Author = "George Karim",
                    Text = "Consuming a Web API"
                }
            };

            return docs;
        }
    }
}
