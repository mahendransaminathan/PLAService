
using PLAService.Entities;
using PLAService.Providers;

namespace PLAService.PersonalServices
{
    public class PersonalService
    {
        private PersonalProvider provider = new PersonalProvider();

        public PersonalService(PersonalProvider personalProvider)
        {
            this.provider = personalProvider ?? throw new ArgumentNullException(nameof(personalProvider));
        }

        public void AddPerson(Person person)
        {
                       
            if (person == null)
            {
                throw new ArgumentException("Person data is required.");
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

            provider.AddPerson(person);            
        }
    }
}