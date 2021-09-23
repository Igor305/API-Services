using BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private readonly IShopsToTMSService _shopsToTMSService;
        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, IShopsToTMSService shopsToTMSService)
        {
            _logger = logger;
            _shopsToTMSService = shopsToTMSService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Scoped Processing Service is working.");

                await _shopsToTMSService.getInfo();

                await Task.Delay(3600000, stoppingToken);
            }
        }
    }
}
