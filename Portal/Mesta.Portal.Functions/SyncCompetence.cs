using Mesta.CompetenceManagement.Features.Competencies.Sync;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Mesta.Portal.Functions
{
    public class SyncCompetence
    {
        private readonly ILogger _logger;
        private readonly ISyncCompetenceFeature _syncCompetence;

        public SyncCompetence(ILoggerFactory loggerFactory, ISyncCompetenceFeature syncCompetenceFeature)
        {
            _logger = loggerFactory.CreateLogger<SyncCompetence>();
            _syncCompetence = syncCompetenceFeature;
        }

        [Function("SyncCompetence")]
        public async Task Run([TimerTrigger("* */4 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"SyncCompetence Timer trigger function executed at: {DateTime.Now}");

            //await _syncCompetence.Execute();
        }
    }
}
