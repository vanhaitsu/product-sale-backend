using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polaby.Services.Notification;
using System.Text;

namespace Services.Notification
{
    
    public class OneSignalPushNotificationService : IOneSignalPushNotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _oneSignalAppId;
        private readonly string _oneSignalRestApiKey;

        public OneSignalPushNotificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _oneSignalAppId = configuration["OneSignal:AppId"];
            _oneSignalRestApiKey = configuration["OneSignal:RestApiKey"];
        }

        public async Task<bool> SendNotificationAsync(string heading, string content, string playerId)
        {
            var requestUri = "https://onesignal.com/api/v1/notifications";

            // Create the payload
            var payload = new
            {
                app_id = _oneSignalAppId,
                headings = new { en = heading },
                contents = new { en = content },
                include_player_ids = new[] { playerId } // Target specific users by their OneSignal player ID
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var requestContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Add Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _oneSignalRestApiKey);

            // Send the request
            var response = await _httpClient.PostAsync(requestUri, requestContent);

            // Check if the request was successful
            return response.IsSuccessStatusCode;
        }
    }
}
