using System.Threading.Tasks;
using MerakiAutomation.Domain.MerakiModels;

namespace MerakiAutomation.Client.Services
{
    public interface IMerakiNetworkQuery
    {
        #region Configuration

        #endregion

        

        #region Methods

        public Task<Network[]> GetNetworksAsync(string orgId);
        
        #endregion
    }
}