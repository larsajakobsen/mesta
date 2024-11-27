using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Get;
using Microsoft.AspNetCore.Components;

namespace Mesta.Portal.Web.Pages.Competence
{
    public partial class CompetencePage : ComponentBase
    {
        [Inject]
        protected IGetCompetenceFeature GetCompetence { get; set; } = null!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public int? Id { get; set; }

        private Mesta.CompetenceManagement.Domain.Competence competence = new();

        protected override async Task OnInitializedAsync()
        {
            if(Id.HasValue)
                competence = await GetCompetence.Execute(Id.Value);
        }
        private void Cancel()
        {
            NavigationManager.NavigateTo("competencies");
        }
        private void Submit()
        {
            NavigationManager.NavigateTo("competencies");
        }
    }
}
