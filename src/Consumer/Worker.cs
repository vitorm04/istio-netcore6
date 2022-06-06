namespace Consumer
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _endpoint;

        public Worker(ILogger<Worker> logger,
                      IHttpClientFactory httpClientFactory,
                      IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _endpoint = configuration["HttpIntegration:Endpoint"];
            _configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient("worker");
            while (cancellationToken.IsCancellationRequested is false)
            {
                try
                {
                    {
                        var response = await httpClient.GetAsync(_endpoint, cancellationToken);
                        _logger.LogInformation(response.StatusCode.ToString());
                        await Task.Delay(2000, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex.ToString());
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping worker!");
            return Task.CompletedTask;
        }
    }
}
