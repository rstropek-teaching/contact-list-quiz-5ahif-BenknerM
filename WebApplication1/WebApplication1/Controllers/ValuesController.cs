using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("/contracts")]
    public class ValuesController : Controller
    {
        private IPersonRepository PersonRepository;


        public ValuesController(IPersonRepository PersonRepository)
        {
            this.PersonRepository = PersonRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person p)
        {

            if (p == null)
            {
                return BadRequest();
            }
            p.Id = this.PersonRepository.GetLast().Id + 1;
            this.PersonRepository.AddPerson(p);
            return CreatedAtRoute("contacts", p);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(PersonRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pers = this.PersonRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (pers == null)
            {
                return NotFound();
            }

            this.PersonRepository.DeleteById(pers.Id);
            return Ok("Deleted Successfully!");
        }
        [HttpGet("findByName/{name}")]
        public IActionResult Findbyname(string name)
        {
            if (name.Equals(""))
            {
                return BadRequest();
            }
            List<Person> sol = new List<Person>();
            foreach (Person pers in this.PersonRepository.GetAll())
            {
                if (pers.FirstName.ToLower().Contains(name.ToLower()) || pers.LastName.ToLower().Contains(name.ToLower()))
                {
                    sol.Add(pers);
                }
            }
            if (!sol.Any())
            {
                return Ok("not found!");
            }
            return Ok(sol);
        }
    }
}
