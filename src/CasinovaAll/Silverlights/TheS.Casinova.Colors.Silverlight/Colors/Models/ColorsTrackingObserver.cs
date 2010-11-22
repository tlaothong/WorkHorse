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
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.Colors.Models
{
    public class ColorsTrackingObserver : TrackingObserverBase
    {
        private Action _action;

        public ColorsTrackingObserver(Action action)
        {
            _action = action;
        }

        protected override void OnUpdateTrackingInformation(TrackingInformation trackingInfo)
        {
            _action();
            StatusTracker.ReleaseWatch(this);
            Dispose();
        }
    }
}
