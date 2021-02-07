using System;
using MediatR;
using Tracker.Models;

namespace Tracker.Application.CQRS.Commands.Tracking
{
    public class SavePackageCommand: IRequest<bool>
    {
        public string TrackingId { get; set; }
        public int UserId { get; set; }
        public PackageDelivererType PackageDeliverer { get; set; }
        private DateTime Date { get; set; }
    }
}