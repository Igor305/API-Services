using System;

namespace BusinessLogicLayer.Models
{
    [Serializable]
    public class WaypointsModel
    {
        public string? id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public TimeWindow[] availabilityWindows { get; set; }
        public string contactPhone { get; set; }
        public string type { get; set; }
        public string dateRegisterNumber { get; set; }
    }
}
