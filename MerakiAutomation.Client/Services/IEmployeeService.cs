using System.Threading.Tasks;
using MerakiAutomation.Domain;

namespace MerakiAutomation.Client.Services
{
    public interface IEmployeeService
    {
        public  Task<Employee[]> GetEmployeesAsync();

        public  Task<Employee> GetEmployeeByIdAsync(int id);

        public Task<Employee> AddEmployee(Employee employee);

        public Task UpdateEmployee(Employee employee);

        public Task DeleteEmployee(int employeeId);
    }
}