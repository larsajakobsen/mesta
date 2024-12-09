using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;

namespace Mesta.CompetenceManagement.Features.Persons.Fetch
{
    public interface IFetchPersonsFeature
    {
        Task<IEnumerable<Person>> Execute();
    }

    internal class FetchPersonsFeature : IFetchPersonsFeature
    {
        private readonly IPersonClient _personClient;

        public FetchPersonsFeature(
            IPersonClient personClient)
        {
            _personClient = personClient;
        }

        public async Task<IEnumerable<Person>> Execute()
        {
            return await _personClient.GetPersons();
        }
    }
}