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
using System.Collections.ObjectModel;

namespace TheS.Casinova.MagicNine.ViewModels
{
    public class TimeIntervalViewModel
    {
        public TimeSpan CreateTimeInterval(ObservableCollection<string> interval)
        {
            TimeSpan timeInterval = new TimeSpan();

            foreach (string time in interval) {

                if (interval.Contains("second")) {
                    string intervalToStr = time.Replace("second", " ");
                    timeInterval = new TimeSpan(0, 0, Convert.ToInt32(intervalToStr.Trim()));
                }
                else if (interval.Contains("minute")) {
                    string intervalToStr = time.Replace("minute", " ");
                    timeInterval = new TimeSpan(0, Convert.ToInt32(intervalToStr.Trim()), 0);
                }
                else if (interval.Contains("hours")) {
                    string intervalToStr = time.Replace("hours", " ");
                    timeInterval = new TimeSpan(Convert.ToInt32(intervalToStr.Trim()), 0, 0);
                }
            }

            return timeInterval;
        }
    }
}
