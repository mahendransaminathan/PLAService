using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PLAService.Entities;
using PLAService.PersonalServices;


namespace PLAService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    public class PersonController : ControllerBase
    {
        PersonalService personalService;

        public PersonController(PersonalService personalService)
        {
            this.personalService = personalService ?? throw new ArgumentNullException(nameof(personalService));
        }
        [HttpPost] // POST: api/person
        public IActionResult AddPerson([FromBody] Person person)
        {            
           personalService.AddPerson(person);

           return Ok(person);            
        }        
    }
}
