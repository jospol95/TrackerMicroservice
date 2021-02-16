using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Tracker.Domain.Tracking
{
    public class Package
    {
        [BsonId]
        private Guid Id { get; set; }
        public string TrackingId { get; set; }
        public string UserId { get; set; }
        private DateTime CreatedDate { get; set; }

        public Package()
        {
            
        }
        public Package(string trackingId, string userId)
        {
            TrackingId = trackingId;
            UserId = userId;
            CreatedDate = DateTime.Now;
        }
    }
    
    
}