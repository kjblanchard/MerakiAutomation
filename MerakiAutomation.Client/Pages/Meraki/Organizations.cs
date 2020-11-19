using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Pages.Meraki
{
    public partial class Organizations
    {
        #region Configuration

        public Organization[] _organizations { get; set; }
        [Inject]
        public IMerakiOrganizationQuery MerakiOrganizationQuery { get; set; }
        
        #endregion

        

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            _organizations = await MerakiOrganizationQuery.GetOrganizationsAsync();
        }

        #endregion
    }
}