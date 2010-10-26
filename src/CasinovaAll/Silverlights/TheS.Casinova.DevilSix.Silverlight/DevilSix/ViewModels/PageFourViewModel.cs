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
using System.ComponentModel;
using PerfEx.Infrastructure;

namespace TheS.Casinova.DevilSix.ViewModels
{
    public class PageFourViewModel : PageThreeViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Page four view model
        /// </summary>
        public PageFourViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }
        
        /// <summary>
        /// Bet หมายเลข 50
        /// </summary>
        public void BetFifty()
        {
            //TODO : Create method bet for No.50's button
        }

        /// <summary>
        /// Bet หมายเลข 100
        /// </summary>
        public void BetOneHundred()
        {
            //TODO : Create method bet for No.100's button
        }

        /// <summary>
        /// Bet หมายเลข 500
        /// </summary>
        public void BetFifHundred()
        {
            //TODO : Create method bet for No.500's button
        }

    }
}
