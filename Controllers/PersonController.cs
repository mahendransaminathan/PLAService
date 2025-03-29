using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using PLAService.Entities;
using PLAService.PersonalServices;
using PLAService.CompanyServices;


namespace PLAService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    public class PersonController : ControllerBase
    {
        PersonalService personalService;
        private readonly ICompanyServiceClient mCompanyServiceClient;

        public PersonController(PersonalService personalService, ICompanyServiceClient companyServiceClient)
        {
            this.personalService = personalService ?? throw new ArgumentNullException(nameof(personalService));
            this.mCompanyServiceClient = companyServiceClient ?? throw new ArgumentNullException(nameof(companyServiceClient)); 
        }
        [HttpPost] // POST: api/person
        public IActionResult AddPerson([FromBody] Person person)
        {            
           personalService.AddPerson(person);

           return Ok(person);            
        }   


        [HttpGet("companynames")] // GET: api/person/companynames
        public async Task<IActionResult> GetCompanyNames()
        {
            List<string> companyNames = await mCompanyServiceClient.GetCompanyNamesAsync();
            return Ok(companyNames);
        }  
    }
}
