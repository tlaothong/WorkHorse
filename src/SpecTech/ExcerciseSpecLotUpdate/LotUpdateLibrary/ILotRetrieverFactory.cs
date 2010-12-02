using System;

namespace PerfEx.Infrastructure.LotUpdate
{
    public interface ILotRetrieverFactory
    {
        Uri PollingUrl { get; set; }
        TimeSpan PollingPeriod { get; set; }
        string LotDataUrlFormatString { get; set; }
        ILotRetriever Create(string fromLotNo);
    }
}
