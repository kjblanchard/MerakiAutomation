using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;

namespace MerakiAutomation.Client.Services
{
    public interface IMerakiOrganizationQuery
    {
        public Task<Organization[]> GetOrganizationsAsync();
    }
}