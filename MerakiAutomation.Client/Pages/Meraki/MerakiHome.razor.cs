using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Domain.MerakiModels;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Pages.Meraki
{
    public partial class MerakiHome
    {
        #region Configuration

        public Organization SelectedOrgParent { get; set; } = new Organization();

        #endregion
    }
}