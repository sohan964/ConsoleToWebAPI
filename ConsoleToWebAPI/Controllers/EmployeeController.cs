using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //emplimanting action types
        
        [Route("")] //Specific type: which can only return a specific by of value
        public IEnumerable<EmployeeModel> GetEmployee()
        {
            return new List<EmployeeModel>()
            {
                 new EmployeeModel() { Id = 1, Name = "Emp1" },
                 new EmployeeModel() { Id = 2, Name = "Emp2"},
                 new EmployeeModel() { Id = 3, Name = "Emp3"}
            };
        }

        [Route("{id}")] //IActionResult
        public IActionResult GetEmployee(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            return Ok(new List<EmployeeModel>()
            {
                 new EmployeeModel() { Id = 1, Name = "Emp2" },
                 new EmployeeModel() { Id = 2, Name = "Emp2" },
                 new EmployeeModel() { Id = 3, Name = "Emp3" },
            });
        }

        [Route("{id}/basic")] //ActionResult<T>: can pass exact type of data
        public ActionResult<EmployeeModel> GetEmployeeBasicDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            } 

            return new EmployeeModel()
            {
                Id = 1,
                Name = "EMp3",
            };
        }
    }
}

