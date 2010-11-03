using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ChipExchange.Models
{
    /// <summary>
    /// การตั้งค่าของการแลกเปลี่ยนชิป
    /// </summary>
    public class ExchangeSettingInformation
    {
        /// <summary>
        /// ชื่อของการตั้งค่า
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// จำนวนชิปขั้นต่ำที่จะแลกเป็นเงินได้
        /// </summary>
        public double MinChipToMoneyExchange { get; set; }

        /// <summary>
        /// จำนวนเงินขั้นต่ำที่จะแลกเป็นชิปเป็นได้
        /// </summary>
        public double MinMoneyToChipExchange { get; set; }

        /// <summary>
        /// อัตราแลกเปลี่ยนของการแลกเงินเป็นชิปเป็น
        /// </summary>
        public double MoneyToChipRate { get; set; }

        /// <summary>
        /// อัตราแลกเปลี่ยนของการแลกเงินเป็นชิปตาย
        /// </summary>
        public double MoneyToBonusChipRate { get; set; }

        /// <summary>
        /// อัตราแลกเปลี่ยนของการแลกชิปเป็น เป็นชิปตาย
        /// </summary>
        public double ChipToBonusChipRate { get; set; }

        /// <summary>
        /// อัตราแลกเปลี่ยนของการแลกชิปเป็น เป็นชิปตาย
        /// </summary>
        public double VoucherToBonusChipRate { get; set; }
    }
}
