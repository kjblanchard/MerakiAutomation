using System.Collections.Generic;

namespace MerakiAutomation.Domain.MerakiModels
{
    public class Network
    {
        #region Configuration

        #endregion

        public string id { get; set; } 
        public string organizationId { get; set; } 
        public string name { get; set; } 
        public string timeZone { get; set; } 
        public object tags { get; set; } 
        public List<string> productTypes { get; set; } 
        public string type { get; set; } 
        public bool disableMyMerakiCom { get; set; } 
        public bool disableRemoteStatusPage { get; set; } 

        #region Methods

        #endregion
    }
}