using System;
namespace PerfEx.Infrastructure.LotUpdate
{
    public interface IStatusTracker
    {
        TimeSpan PollingPeriod { get; set; }
        string LotDataUrlFormatString { get; set; }

        void Initialize(Uri pollingUrl);
        ILotRetrieverFactory LotRetrieverFactory { get; }
        void ReleaseWatch(ITrackingObserver observer);
        IObservable<TrackingInformation> Watch(ITrackingObserver observer);
    }
}
