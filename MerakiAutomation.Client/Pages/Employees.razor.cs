using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MerakiAutomation.Client.Services;
using MerakiAutomation.Domain;
using Microsoft.AspNetCore.Components;

namespace MerakiAutomation.Client.Pages
{
    public partial class Employees
    {
        #region Configuration

        #endregion


        private IEnumerable<Employee> _employees;
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _employees = await EmployeeService.GetEmployeesAsync();
        }


        #region Methods

        #endregion
    }
}