using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<AnimalModel> animals = null;
        public AnimalsController()
        {
            animals = new List<AnimalModel>()
            {
                new AnimalModel()
                {
                    Id = 1, Name= "Bird"
                },

                new AnimalModel()
                {
                    Id= 2 , Name= "Cat"
                }
            };
        }

        [Route("", Name ="fo")]
        public IActionResult GetAnimals()
        {
            
            return Ok(animals);
        }

        [Route("test")] //way to get 202 status code in the project
        public IActionResult GetAnimals202()
        {
            return Accepted("~/api/animals");
        }

        //it also get 202 status code
        [Route("test2")]
        public IActionResult GetAnimals202again()
        {
            return AcceptedAtAction("GetAnimals"); // it will return the url of animals controller
        }
        
        //it also get 202 status code
        [Route("test3")]
        public IActionResult GetAnimals202Route()
        {
            return AcceptedAtRoute("fo"); // it will return the url by Route Name
        }

        //example of bad request 400
        [Route("{name}")]
        public IActionResult GetAnimalsByName(string name)
        {
            if (!name.Contains("ABC"))
            {
                return BadRequest(); //return BadRequest or 400
            }
            return Ok(animals); //return the data
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            return Ok(animals.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("")]
        public IActionResult GetAnimals(AnimalModel animal)
        {
            animals.Add(animal);

            return Created("~/api/animals/"+animal.Id, animal);
        }
    }
}
