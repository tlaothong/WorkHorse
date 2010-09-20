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

namespace ColorsGame.Models
{
    public class GameTable
    {
        public int TableID { get; set; }
        public int GameDuration { get; set; }
        public int Interval { get; set; }
    }
}
