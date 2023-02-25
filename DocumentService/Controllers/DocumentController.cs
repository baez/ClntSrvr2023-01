using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
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
            Document doc = null;
            if (Convert.ToInt16(id) == 1)
            {
                doc = new Document()
                {
                    Id = id,
                    Title = "cstp 1303 news today 2/25 9 AM",
                    Author = "George Karim",
                    Text = "Due to weather conditions, our class is online today :)"
                };
            }
            else
            {
                doc = new Document()
                {
                    Id = id,
                    Title = "cstp 1303 topics today",
                    Author = "George Karim",
                    Text = "Consuming a Web API"
                };
            }

            return doc;
        }
    }
}
