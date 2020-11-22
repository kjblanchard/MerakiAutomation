using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Client.Services.FormHelpers;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Components.Meraki
{
    public partial class NetworksComponent :ICanSubmitForms
    {
        #region Configuration

        private Network[] _networks;

        [Inject] private IMerakiNetworkQuery MerakiNetworkQuery { get; set; }
        [Parameter] public int OrgToLookup { get; set; }
        [Parameter] public Network SelectedNetwork { get; set; }
        [Parameter] public EventCallback<Network> SelectedNetworkChanged { get; set; }

        #endregion


        #region Methods

        protected override async Task OnInitializedAsync()
        {
            var orgIdString = OrgToLookup.ToString();
            _networks = await MerakiNetworkQuery.GetNetworksAsync(orgIdString);

        }

        #endregion

        public void HandleValidSubmit()
        {
            if (SelectedNetwork.name == null) return;
            foreach (var network in _networks)
            {
                if (SelectedNetwork.name != network.name) continue;
                SelectedNetwork = network;
                break;
            }
            SelectedNetworkChanged.InvokeAsync(SelectedNetwork);
        }

        public void HandleInvalidSubmit()
        {
            throw new System.NotImplementedException();
        }
    }
}