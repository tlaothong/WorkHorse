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
    public class PageThreeViewModel : PageTwoViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Page three view model
        /// </summary>
        public PageThreeViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);

        }

        /// <summary>
        /// Bet หมายเลข 20
        /// </summary>
        public void BetTwenty()
        {
            //TODO : Create method bet for No.20's button
        }

    }
}
