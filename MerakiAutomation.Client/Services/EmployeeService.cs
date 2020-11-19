using System.Net.Http;
using System.Threading.Tasks;
using MerakiAutomation.Domain;
using Newtonsoft.Json;

namespace MerakiAutomation.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Configuration

        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion


        #region Methods

        #endregion

        public async Task<Employee[]> GetEmployeesAsync()
        {
            var json = await _httpClient.GetStringAsync("/api/employee");
            return JsonConvert.DeserializeObject<Employee[]>(json);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            
            var json = await _httpClient.GetStringAsync($"/api/employee/{id}");
            return JsonConvert.DeserializeObject<Employee>(json);
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }
    }
}