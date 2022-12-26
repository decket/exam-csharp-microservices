using ExamService.Dtos;
using System.Text;
using System.Text.Json;

namespace ExamService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ISalesDataClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HttpCommandDataClient> _logger;

        public HttpCommandDataClient (HttpClient client, IConfiguration configuration, ILogger<HttpCommandDataClient> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendOrderToSecondService(SpecialOfferReadDto fabric)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(fabric),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync($"{_configuration["SecondService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("--> Sync POST to SecondService was OK!");
            }
            else
            {
                _logger.LogWarning("--> Sync POST to CommandService was NOT OK!");
            }
        }
    }
}
