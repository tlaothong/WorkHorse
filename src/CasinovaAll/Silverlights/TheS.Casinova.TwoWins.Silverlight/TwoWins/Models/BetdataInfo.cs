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
    public class BetdataInfo : WinnerInfo
    {
        public int Round { get; set; }
        public int HandID { get; set; }
        public bool Change { get; set; }
        public double OldBet { get; set; }
        public double Pot { get; set; }
        public string Status { get; set; }
    }
}