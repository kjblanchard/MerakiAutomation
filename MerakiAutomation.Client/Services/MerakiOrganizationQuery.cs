using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MerakiAutomation.Client.Services
{
    public class MerakiOrganizationQuery : IMerakiOrganizationQuery
    {
        #region Configuration

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _key;

        public MerakiOrganizationQuery(HttpClient httpClient, IConfiguration configuration)
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

        public async Task<Organization[]> GetOrganizationsAsync()
        {
            var key = _key;
            var jsonString = await _httpClient.GetStringAsync("https://api.meraki.com/api/v0/organizations");
            // var jsonString = await _httpClient.GetStringAsync("https://swapi.dev/api/people/1"); 
            return JsonConvert.DeserializeObject<Organization[]>(jsonString);
        }

        #endregion
    }
}