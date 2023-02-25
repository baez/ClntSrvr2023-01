using System;
using System.Collections.Generic;
using DataModels;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentRepository documentRepository = new DocumentRepository();


        // The request matched multiple endpoints

        /// <summary>
        /// Sample call uri https://localhost:44385/api/document?id=3
        /// Azure uri https://docservgbk20230224.azurewebsites.net/api/document?id=3
        /// 
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
                if (Convert.ToInt16(val) == 1)
                {
                    document = new Document()
                    {
                        Id = val,
                        Title = "cstp 1303 news today 2/25 9 AM",
                        Author = "George Karim",
                        Text = "Due to weather conditions, our class is online today :)"
                    };
                }
                else
                {
                    document = new Document()
                    {
                        Id = val,
                        Title = "cstp 1303 topics today",
                        Author = "George Karim",
                        Text = "Consuming a Web API"
                    };
                }
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
