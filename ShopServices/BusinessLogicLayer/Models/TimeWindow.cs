using System;

namespace BusinessLogicLayer.Models
{
    [Serializable]
    public class TimeWindow
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
