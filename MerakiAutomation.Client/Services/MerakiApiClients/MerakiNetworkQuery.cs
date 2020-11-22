using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MerakiAutomation.Client.Services
{
    public class MerakiNetworkQuery : IMerakiNetworkQuery
    {

        #region Configuration
        
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _key;

        public MerakiNetworkQuery(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _key = _configuration.GetValue<string>("Keys:Meraki");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue($"{_key}");
            _httpClient.DefaultRequestHeaders.Add("X-Cisco-Meraki-API-Key", $"{_key}");
            _httpClient.DefaultRequestHeaders.Add("Accept-Type", "application/json");
        }
        #endregion

        

        #region Methods

        #endregion

        public async Task<Network[]> GetNetworksAsync(string orgId)
        {
            var jsonString = await _httpClient.GetStringAsync($"organizations/{orgId}/networks");
            return JsonConvert.DeserializeObject<Network[]>(jsonString);
        }
    }
}