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

namespace TheS.Casinova.TwoWins.Models
{
    public class WinnerInfo
    {
        public int Round { get; set; }
        public string GameState { get; set; }
        public DateTime Time { get; set; }
        public string Player { get; set; }
        public double Bet { get; set; }
        public string WinState { get; set; }
        public double Getback { get; set; }
    }
}
