using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;

namespace TheS.Casinova.ChipExchange.BackServices
{
    public interface IChipsExchangeModuleBackService :
        IMoneyToChips,
        IMoneyToBonusChips,
        IChipsToMoney,
        IPayVoucher,
        IVoucherToBonusChips,
        IChipsToBonusChips

    {}

    /// <summary>
    /// แลกชิพเป็นด้วยเงิน
    /// </summary>
    public interface IMoneyToChips
    {
        void MoneyToChips(MoneyToChipsCommand cmd);
    }

    /// <summary>
    /// แลกชิพตายด้วยเงิน
    /// </summary>
    public interface IMoneyToBonusChips
    {
        void MoneyToBonusChips(MoneyToBonusChipsCommand cmd);
    }

    /// <summary>
    /// เปลี่ยนชิพเป็นเป็นเงิน
    /// </summary>
    public interface IChipsToMoney
    {
        void ChipsToMoney(ChipsToMoneyCommand cmd);
    }

    /// <summary>
    /// แลกคูปองด้วยชิพ
    /// </summary>
    public interface IPayVoucher
    {
        void PayVoucher(PayVoucherCommand cmd);
    }

    /// <summary>
    /// แลกชิพตายจากคูปอง
    /// </summary>
    public interface IVoucherToBonusChips
    {
        void VoucherToBonusChips(VoucherToBonusChipsCommand cmd);
    }

    /// <summary>
    /// แลกชิพตายด้วยชิพเป็น
    /// </summary>
    public interface IChipsToBonusChips
    {
        void ChipsToBonusChips(ChipsToBonusChipsCommand cmd);
    }
}
