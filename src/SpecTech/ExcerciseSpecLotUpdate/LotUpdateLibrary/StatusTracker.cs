using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfEx.Infrastructure.LotUpdate
{
    public class StatusTracker : IStatusTracker
    {
        private static readonly TimeSpan _defaultPollingPeriod = TimeSpan.FromMilliseconds(789);
        private static readonly object _SyncRoot = new object();

        private ILotRetriever _retriever;
        private Subject<TrackingInformation> _subject = new Subject<TrackingInformation>();
        private IObservable<TrackingInformation> _publish;
        private List<ITrackingObserver> _observers = new List<ITrackingObserver>();
        private string _latestLotNo;

        private Uri _pollingUrl;

        public Uri PollingUrl
        {
            get { return _pollingUrl; }
        }

        private TimeSpan? _pollingPeriod;

        public TimeSpan PollingPeriod
        {
            get
            {
                if (_pollingPeriod == null) {
                    _pollingPeriod = _defaultPollingPeriod;
                }
                return _pollingPeriod.Value;
            }
            set
            {
                _pollingPeriod = value;
                LotRetrieverFactory.PollingPeriod = value;
            }
        }

        public string LotDataUrlFormatString
        {
            get { return LotRetrieverFactory.LotDataUrlFormatString; }
            set { LotRetrieverFactory.LotDataUrlFormatString = value; }
        }

        private ILotRetrieverFactory _facRetriever;

        public ILotRetrieverFactory LotRetrieverFactory
        {
            get
            {
                if (_facRetriever == null) {
                    throw new InvalidOperationException("LotRetrieverFactory must be set before initialize.");
                }
                return _facRetriever;
            }
            set
            {
                _facRetriever = value;
            }
        }

        public void Initialize(Uri pollingUrl)
        {
            _pollingUrl = pollingUrl;

            _publish = _subject.Publish();
            _latestLotNo = string.Empty;

            var facRetriever = LotRetrieverFactory;
            facRetriever.PollingUrl = pollingUrl;
            facRetriever.PollingPeriod = PollingPeriod;
        }

        public IObservable<TrackingInformation> Watch(ITrackingObserver observer)
        {
            _observers.Add(observer);
            if (_retriever == null) {
                lock (_SyncRoot) {
                    if (_retriever == null) {
                        createLotRetriever();
                    }
                }
            }
            return _publish;
        }

        private void createLotRetriever()
        {
            var retriever = LotRetrieverFactory.Create(_latestLotNo);
            _retriever = retriever;

            retriever.Follow()
                .Subscribe(
                    nx => {
                        _subject.OnNext(nx);
                    }
                    , erx => {
                        _subject.OnError(erx);
                    }
                    , () => { // completed
                        _latestLotNo = _retriever.LatestLotNo;
                        Observable.Return(new Unit()).Delay(PollingPeriod).Subscribe(nx => {
                            if (_observers.Any()) {
                                createLotRetriever();
                            }
                            else {
                                _latestLotNo = string.Empty;
                            }
                        });
                    }
                );
        }

        public void ReleaseWatch(ITrackingObserver observer)
        {
            _observers.Remove(observer);
        }

    }
}
