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

namespace TheS.Casinova.DevilSix.Models
{
    public class WinnerInfo
    {
        public int Round { get; set; }
        public DateTime Time { get; set; }
        public string Winner { get; set; }
        public double Pot { get; set; }
    }
}
