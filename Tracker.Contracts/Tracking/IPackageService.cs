using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Domain.Tracking;

namespace Tracker.Contracts.Tracking
{
    public interface IPackageService
    {
        Task<Guid> Save(string trackingId, string userId);
        Task Delete(Package package);
        Task<IEnumerable<Package>> GetAllByUserId(string userId);
        Task<Package> Get(Guid packageId);
    }
}