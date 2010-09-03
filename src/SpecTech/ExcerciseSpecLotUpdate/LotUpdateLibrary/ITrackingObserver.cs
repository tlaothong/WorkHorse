using System;
using System.Collections.Generic;
using System.Text;

namespace PerfEx.Infrastructure.LotUpdate
{
    public interface ITrackingObserver
    {
        void Initialize(IStatusTracker tracker);
        void SetTrackingID(Guid trackingId);
        void Release();
    }
}
