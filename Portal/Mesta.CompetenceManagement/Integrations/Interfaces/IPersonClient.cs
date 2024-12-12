using Mesta.CompetenceManagement.Domain;

namespace Mesta.CompetenceManagement.Integrations.Interfaces
{
    internal interface IPersonClient
    {
        Task<Person> GetPerson(int id);
        Task<IEnumerable<Person>> GetPersons();
    }
}
