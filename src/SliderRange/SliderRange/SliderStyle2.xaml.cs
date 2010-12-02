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

namespace SliderRange
{
    public partial class SliderStyle2 : UserControl
    {
        public SliderStyle2()
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
            UpperSlider.Value = (int)Math.Max(upper, lower);
            LowerSlider.Value = (int)Math.Min(upper, lower);
			
			//TODO : Check condition
			//condition :: upper and lower must different equal to _minDiff 
            if ((int)e.NewValue != (int)e.OldValue ) {   //check is value change
                if (UpperSlider.Value.Equals(UpperSlider.Minimum)) UpperSlider.Value = (int)LowerSlider.Value + 1;
                else if (LowerSlider.Value.Equals(LowerSlider.Maximum)) LowerSlider.Value = (int)UpperSlider.Value - 1;
				
				//   <<<Upper slider
					else if(UpperSlider.Value.Equals(LowerSlider.Value+1)){
						LowerSlider.Value-=1;  
					}
				//   Lower slider>>>
					else if(LowerSlider.Value.Equals(UpperSlider.Value-1)) {
						UpperSlider.Value+=1;
					}
            }


            // Display
            Maximum.Text = ((int)UpperSlider.Value).ToString();
            Minimum.Text = ((int)LowerSlider.Value).ToString();
            int total = 0;
            for (int startFrom = lower; startFrom <= upper; startFrom++) total += startFrom;
            Total.Text = total.ToString();
        }
    }
}
