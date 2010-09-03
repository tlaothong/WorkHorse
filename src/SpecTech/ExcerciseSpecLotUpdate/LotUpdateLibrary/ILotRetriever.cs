using System;

namespace PerfEx.Infrastructure.LotUpdate
{
    public interface ILotRetriever
    {
        IObservable<TrackingInformation> Follow();
        string LatestLotNo { get; }
    }
}
