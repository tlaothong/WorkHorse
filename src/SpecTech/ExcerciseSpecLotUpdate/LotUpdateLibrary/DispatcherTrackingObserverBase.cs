using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Infrastructure.LotUpdate
{
    public abstract class DispatcherTrackingObserverBase : TrackingObserverBase
    {
        protected override IObservable<TrackingInformation> WrapObservableQuery(IObservable<TrackingInformation> qry)
        {
            return qry.ObserveOnDispatcher();
        }
    }
}
