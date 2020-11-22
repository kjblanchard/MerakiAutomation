namespace MerakiAutomation.Domain.MerakiModels
{
    public class Device
    {
        #region Configuration

        
        public double lat { get; set; } 
        public double lng { get; set; } 
        public string address { get; set; } 
        public string serial { get; set; } 
        public string mac { get; set; } 
        public string lanIp { get; set; } 
        public string tags { get; set; } 
        public string url { get; set; } 
        public string networkId { get; set; } 
        public string name { get; set; } 
        public string model { get; set; } 
        public string firmware { get; set; } 
        public object floorPlanId { get; set; } 
        #endregion

        

        #region Methods

        #endregion
    }
}