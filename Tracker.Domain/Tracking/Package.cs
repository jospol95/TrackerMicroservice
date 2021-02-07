using System;

namespace Tracker.Domain.Tracking
{
    public class Package
    {
        private string Id { get; set; }
        public string TrackingId { get; set; }
        public string UserId { get; set; }
        private DateTime CreatedDate { get; set; }

        public Package(string trackingId, string userId)
        {
            TrackingId = trackingId;
            UserId = userId;
            CreatedDate = DateTime.Now;
        }
    }
    
    
}