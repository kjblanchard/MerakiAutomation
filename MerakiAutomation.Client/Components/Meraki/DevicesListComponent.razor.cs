using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Components.Meraki
{
    public partial class DevicesListComponent
    {
        #region Configuration
        
        private Device[] _devices;
        
        [Inject] private IMerakiDeviceQuery MerakiDeviceQuery { get; set; }
        [Parameter] public string NetworkToLookup { get; set; }

        #endregion

        

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            _devices = await MerakiDeviceQuery.GetDevicesAsync(NetworkToLookup);
        }

        #endregion
    }
}