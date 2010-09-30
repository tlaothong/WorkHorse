using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PerfEx.Infrastructure.Mvvm;

namespace SliderRange
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // change max
            SetMaximumTextBox.TextChanged += (sender, e) => {
                int set = int.Parse((sender as TextBox).Text);
                UpperSlider.Maximum = set;
                LowerSlider.Maximum = set;
            };

            // change min
            SetMinimumTextBox.TextChanged += (sender, e) => {
                int set = int.Parse((sender as TextBox).Text);
                UpperSlider.Minimum = set;
                LowerSlider.Minimum = set;
            };
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var upper = (int)UpperSlider.Value;
            var lower = (int)LowerSlider.Value;

            UpperSlider.Value = Math.Max(upper, lower);
            LowerSlider.Value = Math.Min(upper, lower);

            Maximum.Text = upper.ToString();
            Minimum.Text = lower.ToString();

            int total = 0;
            for (int startFrom = lower; startFrom <= upper; startFrom++)
                total += startFrom;
            Total.Text = total.ToString();
        }
    }
}
