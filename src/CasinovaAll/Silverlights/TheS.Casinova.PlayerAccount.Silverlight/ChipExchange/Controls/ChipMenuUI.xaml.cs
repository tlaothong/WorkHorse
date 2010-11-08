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

namespace TheS.Casinova.ChipExchange.Controls
{
    public partial class ChipMenuUI : UserControl
    {
        private int _selectItem;

        public int SelectItem
        {
            get { return _selectItem; }
            set
            {
                if (_selectItem!=value)
                {
                    _selectItem = value;
                    switch (value)
                    {
                        case 0: changeState(DisplayRefundableChips); break;
                        case 1: changeState(DisplayNonRefundableChips); break;
                        case 2: changeState(DisplayGiftVoucher); break;
                        default: changeState(Default); break;
                    }
                }
            }
        }

        public ChipMenuUI()
        {
            InitializeComponent();
        }

        private void changeState(VisualState stateName)
        {
            VisualStateManager.GoToState(this, stateName.Name, false);
        }
    }
}
