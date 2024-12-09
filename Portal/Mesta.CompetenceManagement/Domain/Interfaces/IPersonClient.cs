namespace Mesta.CompetenceManagement.Domain.Interfaces
{
    public interface IPersonClient
    {
        Task<Person> GetPerson(int id);
        Task<IEnumerable<Person>> GetPersons();
    }
}
