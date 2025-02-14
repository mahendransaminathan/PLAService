using PLAService.Data;
using PLAService.Entities;

namespace PLAService.Providers
{
    public class PersonalProvider
    {
        private readonly ApplicationDBContext? dbContext;

        public PersonalProvider()
        {
         
        }
        public PersonalProvider(ApplicationDBContext dbContext)
        {            
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddPerson(Person person)
        {
           if (dbContext == null)
            {
                throw new InvalidOperationException("Database context is not available.");
            }

            dbContext.People.Add(person);
            dbContext.SaveChanges();    
        }       
    }         
}