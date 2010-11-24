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

namespace TheS.Casinova.Colors.Models
{
    public class PayLog
    {
        public int TableID { get; set; }
        public int RoundID { get; set; }
        public double Amount { get; set; }
        public Guid TrackingID { get; set; }
        public string Colors { get; set; }
    }
}
