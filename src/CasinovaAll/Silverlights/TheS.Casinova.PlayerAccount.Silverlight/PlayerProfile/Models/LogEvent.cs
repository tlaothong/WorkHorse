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

namespace TheS.Casinova.PlayerProfile.Models
{
    public class LogEvent
    {
        public DateTime Time { get; set; }
        public string Action { get; set; }
        public double Money { get; set; }
    }
}
