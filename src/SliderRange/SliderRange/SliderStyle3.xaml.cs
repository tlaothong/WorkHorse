using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SliderRange
{
	public partial class SliderStyle3 : UserControl
	{
        private int _maximum = 10;
        private int _minimum = 0;

		public SliderStyle3()
		{
			InitializeComponent();
            setSliderRange();

            UpperSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(UpperSlider_ValueChanged);
            LowerSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(LowerSlider_ValueChanged);
		}

        // upper slider
        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int upper = (int)UpperSlider.Value;
            int lower = (int)LowerSlider.Value;
            LowerTextBlock.Text = lower.ToString();
            SummationTextBlock.Text = getSummation(upper, lower).ToString();
        }

        // upper slider
        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int upper = (int)UpperSlider.Value;
            int lower = (int)LowerSlider.Value;
            UpperTextBlock.Text = upper.ToString();
            SummationTextBlock.Text = getSummation(upper, lower).ToString();
        }

        private void setSliderRange()
        {
            // upper
            UpperSlider.Maximum = _maximum;
            UpperSlider.Minimum = _minimum;
            UpperSlider.Value = _minimum;

            // lower
            LowerSlider.Maximum = _maximum;
            LowerSlider.Minimum = _minimum;
            LowerSlider.Value = _minimum;
        }

        private void Slider_LayoutUpdated(object sender, System.EventArgs e)
        {
            // Edge upper & lower
            if ((int)UpperSlider.Value <= _minimum) UpperSlider.Value = _minimum + 1;
            if ((int)LowerSlider.Value >= _maximum) LowerSlider.Value = _maximum - 1;
        }

        private void MaxAndMinChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _maximum = int.Parse(InputMaxTextBox.Text);
            _minimum = int.Parse(InputMinTextBox.Text);
            setSliderRange();
        }

        private int getSummation(int upper,int lower)
        {
            // summation
            int end = Math.Max(upper, lower);
            int startBy = Math.Min(upper, lower);
            int summation = 0;
            while (startBy <= end) summation += startBy++;
            return summation;
        }
	}
}