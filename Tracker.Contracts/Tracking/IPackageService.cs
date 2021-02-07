using System.Threading.Tasks;

namespace Tracker.Contracts.Tracking
{
    public interface IPackageService
    {
        Task Save(string packageId, string userId);
    }
}