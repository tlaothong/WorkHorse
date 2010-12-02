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

namespace TheS.Casinova.MagicNine
{
    public class MagicNineTrackingObserver : TrackingObserverBase
    {
        private Action _action;

        public MagicNineTrackingObserver(Action action)
        {
            _action = action;
        }

        public void ReleaseWatch()
        {
            StatusTracker.ReleaseWatch(this);
            Dispose();
        }

        protected override void OnUpdateTrackingInformation(TrackingInformation trackingInfo)
        {
            _action();
        }
    }
}
