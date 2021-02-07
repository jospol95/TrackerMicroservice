using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tracker.Contracts.Tracking;
using Tracker.Domain.Tracking;

namespace Tracker.Infrastructure.Services.Tracking
{
    public class PackageService : IPackageService
    {
        private readonly IMongoCollection<Package> _packages;

        public PackageService()
        {
            var client = new MongoClient("connectionString");
            var database = client.GetDatabase("databaseName");
            _packages = database.GetCollection<Package>("collectionName");
        }
        
        public async Task Save(string trackingId, string userId)
        {
            var newPackage = new Package(trackingId, userId);
            await _packages.InsertOneAsync(newPackage);
        }

        public async Task<IEnumerable<Package>> GetAll(string userId)
        {
            return await _packages.Find<Package>(package => package.UserId == userId).ToListAsync();
        }
        
        public async Task<Package> Get(string trackingId)
        {
            return await _packages.Find<Package>(package => package.TrackingId == trackingId).FirstOrDefaultAsync();
        }
    }
}