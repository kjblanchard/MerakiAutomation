using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MerakiAutomation.Client.Services
{
    public class MerakiDeviceQuery : IMerakiDeviceQuery
    {
        #region Configuration

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _key;

        #endregion

        public MerakiDeviceQuery(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _httpClient = httpClient;
            _configuration = configuration;
            _key = _configuration.GetValue<string>("Keys:Meraki");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue($"{_key}");
            _httpClient.DefaultRequestHeaders.Add("X-Cisco-Meraki-API-Key", $"{_key}");
        }


        #region Methods

        #endregion

        public async Task<Device[]> GetDevicesAsync(string networkId)
        {
            _httpClient.DefaultRequestHeaders.Add("Accept-Type", "application/json");
            var jsonString = await _httpClient.GetStringAsync($"networks/{networkId}/devices");
            _httpClient.DefaultRequestHeaders.Remove("Accept-Type");
            return JsonConvert.DeserializeObject<Device[]>(jsonString);
        }

        public async Task UpdateDeviceName(Device deviceToUpdate)
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            
            // _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            var deviceJsonString = JsonConvert.SerializeObject(deviceToUpdate);
            var content = new StringContent(deviceJsonString,Encoding.UTF8, 
                "application/json");
            var response =
                await _httpClient.PutAsync($"networks/{deviceToUpdate.networkId}/devices/{deviceToUpdate.serial}",
                    content);

            _httpClient.DefaultRequestHeaders.Remove("Accept");
        }
    }
}