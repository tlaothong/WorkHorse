using System;
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
        private const string SingleState = "Single";
        private const string RangeState = "Range";
        private bool _isSingle;

		public HighAndLowPage()
		{
			// Required to initialize variables
			InitializeComponent();
			MvvmBinder.Bind(this, DataContext);
		}

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            if (_isSingle) changeState(SingleState);
            else changeState(RangeState);
            _isSingle = !_isSingle;
        }

        private void changeState(string stateName)
        {
            VisualStateManager.GoToState(this,stateName,false);
        }

        private void ChangeStateToSingle(object sender, RoutedEventArgs e)
        {
            _isSingle = false;
        }
	}
}