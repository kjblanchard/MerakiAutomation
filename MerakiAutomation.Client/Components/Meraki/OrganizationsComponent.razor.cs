using System;
using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Client.Services.FormHelpers;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Components.Meraki
{
    public partial class OrganizationsComponent : ICanSubmitForms
    {
        #region Configuration

        private Organization[] _organizations;
        [Inject] private IMerakiOrganizationQuery MerakiOrganizationQuery { get; set; }
        [Parameter] public Organization SelectedOrganization { get; set; }
        [Parameter] public EventCallback<Organization> SelectedOrganizationChanged { get; set; }


        #endregion


        #region Methods

        protected override async Task OnInitializedAsync()
        {
            _organizations = await MerakiOrganizationQuery.GetOrganizationsAsync();
        }

        public void HandleValidSubmit() 
        {
            if (SelectedOrganization.Name == null) return;
            foreach (var organization in _organizations)
            {
                if (SelectedOrganization.Name == organization.Name)
                {
                    SelectedOrganization = organization;
                }
            }
            SelectedOrganizationChanged.InvokeAsync(SelectedOrganization);
        }
        
        public void HandleInvalidSubmit()
        {
        }

        #endregion
    }
}