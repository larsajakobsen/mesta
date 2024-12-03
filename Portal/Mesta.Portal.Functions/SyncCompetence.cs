using System;
using Mesta.Portal.Application.Features.Competence.Sync;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Mesta.Portal.Functions
{
    public class SyncCompetence
    {
        private readonly ILogger _logger;
        private readonly SyncCompetenceFeature _syncCompetence;

        public SyncCompetence(ILoggerFactory loggerFactory, SyncCompetenceFeature syncCompetenceFeature)
        {
            _logger = loggerFactory.CreateLogger<SyncCompetence>();
            _syncCompetence = syncCompetenceFeature;
        }

        [Function("SyncCompetence")]
        public async Task Run([TimerTrigger("*/30 * * * * *", RunOnStartup = true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }

            await _syncCompetence.Execute();
        }
    }
}
