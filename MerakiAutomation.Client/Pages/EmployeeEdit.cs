using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Domain;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Pages
{
    public partial class EmployeeEdit
    {
        #region Configuration

        [Inject] private IEmployeeService EmployeeService { get; set; }
        [Parameter] public string Id { get; set; }
        private Employee Employee { get; set; } = new Employee();

        #endregion


        #region Methods

        protected override async Task OnInitializedAsync()
        {
            var num = int.Parse(Id);
            Employee = await EmployeeService.GetEmployeeByIdAsync(num);
        }

        #endregion
    }
}