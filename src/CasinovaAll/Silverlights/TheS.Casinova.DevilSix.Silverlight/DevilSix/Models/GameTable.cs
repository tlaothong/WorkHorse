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

namespace TheS.Casinova.DevilSix.Models
{
    public class GameTable
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool IsPlaying { get; set; }
        public ObservableCollection<int> Reception { get; set; }
    }
}
