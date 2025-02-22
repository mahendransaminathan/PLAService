using PLAService.Entities;

namespace PLAService.PersonalServices
{
    public interface IPersonalService
    {
        void AddPerson(Person person);
    }
}
// Compare this snippet from Providers/PersonalProvider.cs:
// using PLAService.Entities;