using Microsoft.AspNetCore.Mvc;
using PLAService.Entities;

namespace PLAService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return Ok(newPerson);            
        }        
    }
}
