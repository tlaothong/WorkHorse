using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfEx.Infrastructure.LotUpdate
{
    public abstract partial class TrackingObserverBase : ITrackingObserver
    {
        private IStatusTracker _tracker;
        private Guid _trackingId;
        private IDisposable _subscription;
        private Subject<Guid> _subjTrigMonitor = new Subject<Guid>();
        
        public virtual void Initialize(IStatusTracker tracker)
        {
            _tracker = tracker;
            var qry = (from it in tracker.Watch(this)
                       from trackingId in _subjTrigMonitor
                       where it.TrackingID == trackingId
                       select it);
            qry = WrapObservableQuery(qry);
            _subscription = qry.Subscribe(
                    nx => {
                    }
                    , OnError
                    , OnCompleted
                );
        }

        public virtual void SetTrackingID(Guid trackingId)
        {
            _trackingId = trackingId;
            _subjTrigMonitor.OnNext(trackingId);
        }

        public virtual void Release()
        {
            _subscription.Dispose();
        }

        protected abstract void OnUpdateTrackingInformation(TrackingInformation trackingInfo);

        protected virtual void OnError(Exception ex) { }
        protected virtual void OnCompleted() { }

        protected virtual IObservable<TrackingInformation> WrapObservableQuery(IObservable<TrackingInformation> qry)
        {
            return qry;
        }
    }
}
