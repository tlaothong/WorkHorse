﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PerfEx.Infrastructure.Mvvm;

namespace HighAndLow
{
	public partial class HighAndLowPage : UserControl
	{
		public HighAndLowPage()
		{
			// Required to initialize variables
			InitializeComponent();
			MvvmBinder.Bind(this, DataContext);
		}
	}
}