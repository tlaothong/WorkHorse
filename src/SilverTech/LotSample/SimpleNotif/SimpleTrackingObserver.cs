using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.LotUpdate;

namespace SimpleNotif
{
    public class SimpleTrackingObserver : TrackingObserverBase
    {
        //private Action<TrackingInformation> _notifyBack;

        //public SimpleTrackingObserver(Action<TrackingInformation> notifyBack)
        //{
        //    _notifyBack = notifyBack;
        //}

        protected override void OnUpdateTrackingInformation(TrackingInformation trackingInfo)
        {
            //_notifyBack(trackingInfo);
            throw new InvalidOperationException("???????");
            MessageBox.Show(trackingInfo.Status);
            StatusTracker.ReleaseWatch(this);
        }
    }
}
