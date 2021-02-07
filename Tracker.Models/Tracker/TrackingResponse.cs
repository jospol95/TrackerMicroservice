using System;

namespace Tracker.Models.Tracker
{
    public class TrackingResponse
    {
        public DateTime CurrentDate { get; set; }
        public TimeSpan TimeTakenForRequest { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string DeliverToAddress { get; set; }
        public string DeliverTo { get; set; }
        public string CurrentStatus { get; set; }
        //public Status status {get;set;}
    }
}