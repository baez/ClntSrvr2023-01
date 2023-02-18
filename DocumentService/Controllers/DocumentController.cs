using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<Document> Get(string id)
        {
            var doc = new Document()
            {
                Id = id,
                Title = "Global News International 2/18 2023 11:33 AM",
                Author = "CJ Edwards",
                Text = "news ... more news ... "
            };

            return doc;
        }
    }
}
