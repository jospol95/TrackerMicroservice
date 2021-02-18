using System;

namespace Tracker.Application.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        
        public RecordNotFoundException () {}
        public RecordNotFoundException(string message)
            : base(message) { }
    }
}