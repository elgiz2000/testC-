using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DataAccess.Abstract;
using Test.Entities;

namespace Test.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private ITestRepository _testRepository;
        public DogsController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string attribute, string order) 
        { 
            var dogs = await _testRepository.GetDogs();
            var query = dogs;
            attribute = attribute?.ToLower();
            order = order?.ToLower();
            switch (attribute)
            {
                case "name":
                    if (order == "desc")
                    {
                        query = dogs.OrderByDescending(c => c.Name).ToList();
                    }
                    else
                    {
                        query = dogs.OrderBy(c => c.Name).ToList();
                    }
                    break;
                 case "color":
                    if (order == "desc")
                    {
                        query = dogs.OrderByDescending(c => c.Color).ToList();
                    }
                    else
                    {
                        query = dogs.OrderBy(c => c.Color).ToList();
                    }
                    break;
                 case "tail_length":
                    if (order == "desc")
                    {
                        query = dogs.OrderByDescending(c => c.Tail_length).ToList();
                    }
                    else
                    {
                        query = dogs.OrderBy(c => c.Tail_length).ToList();
                    }
                    break;
                case "id":
                    if (order == "desc")
                    {
                        query = dogs.OrderByDescending(c => c.Id).ToList();
                    }
                    else
                    {
                        query = dogs.OrderBy(c => c.Id).ToList();
                    }
                    break;
                case "weight":
                    if (order == "desc")
                    {
                        query = dogs.OrderByDescending(c => c.Weight).ToList();
                    }
                    else
                    {
                        query = dogs.OrderBy(c => c.Weight).ToList();
                    }
                    break;
            }
            if (attribute != null && order != null) return Ok(query);
            else return Ok(dogs);
           
            
        }

        

        [HttpPost("/dog")]
        public async Task<IActionResult> Post([FromBody] Dog dog)
        {
            if (dog.Tail_length <= 0 ) return NotFound("Invalid request");
                var createdDog = await _testRepository.CreateDog(dog);
                return CreatedAtAction("Get", new { id = createdDog.Id }, createdDog);


        }

        [HttpGet("/ping")]
        public ActionResult<string> MyAction()
        {
            return "Dogs house service. Version 1.0.1";
        }

       

    }
}
