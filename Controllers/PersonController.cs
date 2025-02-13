using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PLAService.Entities;

namespace PLAService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    public class PersonController : ControllerBase
    {
        [HttpPost] // POST: api/person
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person data is required.");
            }
            var newPerson = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                AddressLine1 = person.AddressLine1,
                AddressLine2 = person.AddressLine2,
                City = person.City,
                Country = person.Country,
                Eircode = person.Eircode,
                PhoneNumber = person.PhoneNumber,
                EmailID = person.EmailID
            };
            Console.WriteLine("Person Data: " + person);

            return Ok(newPerson);            
        }        
    }
}
