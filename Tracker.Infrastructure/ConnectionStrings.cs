namespace Tracker.Infrastructure
{
    public class ConnectionStrings
    {
        public string TrackingMongoDbUrl { get; set; }
        //todo see where I can put this
        public readonly string TrackingMongoDbName = "TrackingDb";
    }
}