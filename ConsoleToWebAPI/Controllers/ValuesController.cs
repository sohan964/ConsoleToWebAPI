using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        //[Route("api/get-all")]
        public string GetAll()
        {
            return "HEllo getAll";
        }

        //[Route("api/get-authors")]
        public string GetAllAuthors()
        {
            return "hellow getALLAOuth";
        }

        //[Route("books/{id}")]
        public string GetById(int id)
        {
            return $"Hello {id}";
        }

        //[Route("books/{id}/author/{author}")]
        [Route("{id}/{author}")]
        public string GetAuthor(int id, int author)
        {
            return $"hello {id} {author}";
        }
    }
}
