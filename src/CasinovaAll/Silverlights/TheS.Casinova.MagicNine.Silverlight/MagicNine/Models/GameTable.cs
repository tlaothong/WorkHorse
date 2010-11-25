﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TheS.Casinova.MagicNine.Models
{
    public class GameTable
    {
        public int Round { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool IsPlaying { get; set; }
    }
}
