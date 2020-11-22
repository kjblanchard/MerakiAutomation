using MerakiAutomation.Client.Services;
using MerakiAutomation.Client.Services.FormHelpers;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Components.Meraki
{
    public partial class DeviceOptionsComponent : ICanSubmitForms
    {
        #region Configuration

        [Inject] public IMerakiDeviceQuery MerakiDeviceQuery { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public Device DeviceToDisplay { get; set; }

        #endregion


        #region Methods

        #endregion

        public void HandleValidSubmit()
        {
            MerakiDeviceQuery.UpdateDeviceName(DeviceToDisplay);
            NavigationManager.NavigateTo("/");
        }

        public void HandleInvalidSubmit()
        {
        }
    }
}