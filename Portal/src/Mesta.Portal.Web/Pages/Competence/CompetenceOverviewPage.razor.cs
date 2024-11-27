using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Microsoft.AspNetCore.Components;

namespace Mesta.Portal.Web.Pages.Competence
{
    public partial class CompetenceOverviewPage : ComponentBase
    {
        [Inject]
        protected IFetchCompetenceListFeature FetchCompetenceListFeature { get; set; } = null!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;

        public List<Mesta.CompetenceManagement.Domain.Competence> CompetenceList = [];

        private string GetCompetenceUrl(int id) => $"/competencies/{id}/edit";

        private void NavigateToRegister(){
            NavigationManager.NavigateTo("competencies/register");
        }

        protected override async Task OnInitializedAsync()
        {
            CompetenceList = await FetchCompetenceListFeature.Execute();
        }
    }
}
