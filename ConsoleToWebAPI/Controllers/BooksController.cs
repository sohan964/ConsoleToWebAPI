using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{id:int:min(10)}")]
        public string GetById(int id)
        {
            return $"hello int {id}";
        }

        [Route("{id:minlength(3)}")] //same way to define maxlength(a), length(s)
        //range(a,b), alfha also.
        public string GetById(string id)
        {
            return $"hello string {id}";
        }

        [Route("{id:regex(a(b|c))}")]
        public string GetByIdRegex(string id)
        {
            return $"hello string regex {id}";
        }
    }
}
