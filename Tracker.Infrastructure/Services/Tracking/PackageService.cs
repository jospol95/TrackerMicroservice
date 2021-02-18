using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tracker.Contracts.Tracking;
using Tracker.Domain.Tracking;

namespace Tracker.Infrastructure.Services.Tracking
{
    public class PackageService : IPackageService
    {
        private readonly IMongoCollection<Package> _packages;
        private readonly ConnectionStrings _connectionStrings;

        public PackageService(IOptions<ConnectionStrings> options)
        {
            // var client = new MongoClient("connectionString");
            _connectionStrings = options.Value; 
            var client = new MongoClient(_connectionStrings.TrackingMongoDbUrl);
            var database = client.GetDatabase(_connectionStrings.TrackingMongoDbName);
            _packages = database.GetCollection<Package>(nameof(Package));
        }
        
        public async Task<Guid> Save(string trackingId, string userId)
        {
            var newPackage = new Package(trackingId, userId);
            await _packages.InsertOneAsync(newPackage);
            return newPackage.Id;
        }
        
        public async Task Delete(Package packageToDelete)
        {
            // var package = await _packages
            //     .Find(p => p.Id == packageId).SingleAsync();
            await _packages.DeleteOneAsync(p => p.Id == packageToDelete.Id);
        }
        
        public async Task<IEnumerable<Package>> GetAllByUserId(string userId)
        {
            return await _packages
                .Find<Package>(package => package.UserId == userId).ToListAsync();
        }
        
        public async Task<Package> Get(Guid packageId)
        {
            var package = await _packages
                .Find<Package>(package => package.Id == packageId)
                .FirstOrDefaultAsync();
            
            return await _packages
                .Find<Package>(package => package.Id == packageId)
                .FirstOrDefaultAsync();
        }
    }
}