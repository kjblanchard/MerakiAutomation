using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;

namespace MerakiAutomation.Client.Services
{
    public interface IMerakiDeviceQuery
    {
        public Task<Device[]> GetDevicesAsync(string networkId);
        public Task UpdateDeviceName(Device deviceToUpdate);

    }
}